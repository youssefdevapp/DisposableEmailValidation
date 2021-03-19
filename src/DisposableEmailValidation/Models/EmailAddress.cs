using System;

namespace DisposableEmailValidation.Models
{
    public class EmailAddress
    {
        public string Email { get; set; }
        public string Domain
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))                
                return string.Empty;

                return Email.Split('@')[1];
            }
        }

        public EmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email), "Is null or empty");

            Email = email;
        }
    }
}