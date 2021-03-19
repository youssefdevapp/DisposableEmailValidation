using DisposableEmailValidation.Interfaces;
using DisposableEmailValidation.Models;
using DisposableEmailValidation.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Sockets;

namespace DisposableEmailValidation.Services
{
    public class ValidateEmailService : IValidateEmailService
    {
        private readonly ILogger<ValidateEmailService> _logger;
        private readonly IUtilsRepository _utilsRepository;

        public ValidateEmailService(ILogger<ValidateEmailService> logger, IUtilsRepository utilsRepository)
        {
            _logger = logger;
            _utilsRepository = utilsRepository;
        }

        public bool IsValidEmailAddressFormat(EmailAddress emailAdress) => emailAdress?.Email != null && new EmailAddressAttribute().IsValid(emailAdress.Email);

        public bool IsEmailAddressRealDomain(EmailAddress emailAdress)
        {
            bool isReal;

            try
            {
                string hostname = emailAdress.Domain;

                IPHostEntry IPhst = Dns.GetHostEntry(hostname);
                IPEndPoint endPt = new IPEndPoint(IPhst.AddressList[0], 25);
                Socket s = new Socket(endPt.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(endPt);
                s.Close();

                isReal = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                isReal = false;
            }

            return isReal;
        }

        public bool IsDomainBlackListed(EmailAddress emailAdress)
        {
            var blackListDomain = _utilsRepository.GetBlackListDomain();

            return emailAdress.Domain != string.Empty ? blackListDomain.Contains(emailAdress.Domain) : true;
        }
    }
}