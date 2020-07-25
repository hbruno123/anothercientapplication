using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;
        private readonly IPostRepositorio _postRepositorio;
        private readonly IRepository<User> _userRepositorio;
        private readonly IRepository<Comment> _commentRepositorio;

        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IPostRepositorio PostRepository => _postRepositorio ?? new PostRepository(_context);

        public IRepository<User> UserRepository => _userRepositorio ?? new BaseRepositorio<User>(_context);

        public IRepository<Comment> CommentRepository => _commentRepositorio ?? new BaseRepositorio<Comment>(_context);

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
