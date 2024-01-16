using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PersonalBlog.Interface;
using PersonalBlog.Models;

namespace PersonalBlog.Strategies;

public class SqlServerDataService : IDataService, IDisposable
{
    private readonly SqlConnection _connection;

    public SqlServerDataService(IConfiguration configuration)
    {
        var connString = configuration.GetValue<string>("SqlConnection");
        _connection = new SqlConnection(connString);
    }

    public async Task Create(Post model)
    {
        using (var cmd = _connection.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CREATE_POST";
            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@PostDateTime", model.PostDateTime);
            cmd.Parameters.AddWithValue("@Title", model.Title);
            cmd.Parameters.AddWithValue("@Content", model.Content);

            if (_connection.State != ConnectionState.Open)
                await _connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }

    public async Task<List<Post>> GetAll()
    {
        var result = new List<Post>();

        using (var cmd = _connection.CreateCommand())
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_ALL";

            if (_connection.State != ConnectionState.Open)
                await _connection.OpenAsync();

            var reader = await cmd.ExecuteReaderAsync();
            await MapToList(reader, result);
        }

        return result;
    }

    public void Dispose()
    {
        _connection.Dispose();
    }

    private async Task MapToList(SqlDataReader reader, List<Post> result)
    {
        // As an exercise, you can inject AutoMapper and use it instead of the below code

        while (await reader.ReadAsync())
        {
            var model = new Post
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")).ToString(),
                PostDateTime = reader.GetDateTime(reader.GetOrdinal("PostDateTime")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Content = reader.GetString(reader.GetOrdinal("Content"))
            };

            result.Add(model);
        }
    }
}