using System.ComponentModel.DataAnnotations;

namespace SJERP.Business.Authentication.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}