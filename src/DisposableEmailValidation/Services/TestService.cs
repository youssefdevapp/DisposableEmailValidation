using DisposableEmailValidation.Interfaces;
using DisposableEmailValidation.Models;
using DisposableEmailValidation.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DisposableEmailValidation.Services
{
    public class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;
        private readonly IValidateEmailService _validateEmailService;
        private readonly IUserRepository _userRepository;

        public TestService(ILogger<TestService> logger, IValidateEmailService validateEmailService, IUserRepository userRepository)
        {
            _logger = logger;
            _validateEmailService = validateEmailService;
            _userRepository = userRepository;
        }

        public void Run()
        {
            _logger.LogInformation("Start test emails");
            var usersMails = _userRepository.GetUsersEmail();

            foreach (var email in usersMails)
            {
                _validateEmailService.IsValidEmailAddressFormat(email);
                _validateEmailService.IsDomainBlackListed(email);
                _validateEmailService.IsEmailAddressRealDomain(email);
            }

            _logger.LogInformation("End test emails");
        }
    }
}