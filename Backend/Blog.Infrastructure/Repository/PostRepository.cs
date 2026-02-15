using Blog.Domain.Entity;
using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context) => _context = context;

        public async Task AddAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetAllAsync() => await _context.Posts.ToListAsync();

        public async Task<IEnumerable<Post>> GetAllByAuthorIdAsync(User user) => await _context.Posts
             .Where(p => p.User.Id == user.Id)
             .ToListAsync();

        public async Task<Post?> GetByIdAsync(int id) => await _context.Posts.FindAsync(id);

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
