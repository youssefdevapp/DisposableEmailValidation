using DisposableEmailValidation.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DisposableEmailValidation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UtilsRepository> _logger;
        private readonly AppSettings _config;

        public UserRepository(IOptions<AppSettings> config, ILogger<UtilsRepository> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public List<EmailAddress> GetUsersEmail()
        {
            var dir = Directory.GetCurrentDirectory();
            string json = File.ReadAllText($"{dir}\\ConfigFiles\\{_config.Database.ConnectionStrings.Users}");
            List<string> emails = JsonConvert.DeserializeObject<List<string>>(json);

            return emails.Select(s => new EmailAddress(s)).ToList();
        }
    }
}