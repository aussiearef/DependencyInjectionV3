using System;
using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace PersonalBlog.Models;

[DynamoDBTable("blog")]
public class Post
{
    [DynamoDBHashKey] public string Id { get; set; } = Guid.NewGuid().ToString();

    public DateTime PostDateTime { get; set; } = DateTime.Now;

    [Required] public string Title { get; set; }

    public string Content { get; set; }
}