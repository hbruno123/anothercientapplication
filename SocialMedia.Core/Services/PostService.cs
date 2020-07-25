using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetPosts()
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _unitOfWork.PostRepository.GetById(id);

            return post;
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if (user == null)
                throw new BusinessException("Usuario no existe");

            if (post.Description.Contains("sexo"))
                throw new BusinessException("Contenido no permitido");

            var userPost = await _unitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if(userPost != null && userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=> x.Date).FirstOrDefault();
                if((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("No puedes publicar más de un post en una semana");
                }
            }


            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }


    }
}
