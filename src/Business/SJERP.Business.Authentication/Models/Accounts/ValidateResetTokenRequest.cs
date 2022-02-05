using System.ComponentModel.DataAnnotations;

namespace SJERP.Business.Authentication.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}