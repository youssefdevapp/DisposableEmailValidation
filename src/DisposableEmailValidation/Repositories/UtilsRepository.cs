using DisposableEmailValidation.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DisposableEmailValidation.Repositories
{
    public class UtilsRepository : IUtilsRepository
    {
        private readonly ILogger<UtilsRepository> _logger;
        private readonly AppSettings _config;

        public UtilsRepository(IOptions<AppSettings> config, ILogger<UtilsRepository> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public List<string> GetBlackListDomain()
        {
            var dir = Directory.GetCurrentDirectory();
            string json = File.ReadAllText($"{dir}\\ConfigFiles\\{_config.Database.ConnectionStrings.Utils}");
            return JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}