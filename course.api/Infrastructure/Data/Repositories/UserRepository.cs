using course.api.Business.Entities;
using course.api.Repositories;
using System.Linq;

namespace course.api.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _context;

        public UserRepository(CourseDbContext context)
        {
            this._context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public User ObterUsuario(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
