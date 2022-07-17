using Bookshop.Entities;

namespace Bookshop.Business.Interfaces
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
