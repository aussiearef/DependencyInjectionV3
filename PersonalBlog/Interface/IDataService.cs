using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalBlog.Models;

namespace PersonalBlog.Interface;

public interface IDataService
{
    Task Create(Post model);
    Task<List<Post>> GetAll();
}