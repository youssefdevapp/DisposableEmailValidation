using DisposableEmailValidation.Models;

namespace DisposableEmailValidation.Interfaces
{
    public interface IValidateEmailService
    {
        bool IsValidEmailAddressFormat(EmailAddress emailAdress);
        bool IsEmailAddressRealDomain(EmailAddress emailAdress);
        bool IsDomainBlackListed(EmailAddress emailAdress);
    }
}