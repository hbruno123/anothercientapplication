using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositorios
{
    public class PostRepository : BaseRepositorio<Post>, IPostRepositorio
    {
        public PostRepository(SocialMediaContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Post>> GetPostsByUser(int id)
        {
            return await _entities.Where(x => x.UserId == id).ToListAsync();
        }
    }
}
