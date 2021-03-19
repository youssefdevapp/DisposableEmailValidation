using DisposableEmailValidation.Models;
using System.Collections.Generic;

namespace DisposableEmailValidation.Repositories
{
    public interface IUserRepository
    {
        List<EmailAddress> GetUsersEmail();
    }
}