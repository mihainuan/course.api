using course.api.Business.Entities;

namespace course.api.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Commit();
        User ObterUsuario(string login);
    }
}
