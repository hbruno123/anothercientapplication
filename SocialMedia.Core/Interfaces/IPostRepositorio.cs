using SocialMedia.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepositorio : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUser(int id);
    }
}
