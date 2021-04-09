using course.api.Models;

namespace course.api.Configuratioins
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserViewModelOutput userViewModelOutput);
    }
}
