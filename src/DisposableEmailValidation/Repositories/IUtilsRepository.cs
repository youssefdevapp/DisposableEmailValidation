using System.Collections.Generic;

namespace DisposableEmailValidation.Repositories
{
    public interface IUtilsRepository
    {
        List<string> GetBlackListDomain();
    }
}