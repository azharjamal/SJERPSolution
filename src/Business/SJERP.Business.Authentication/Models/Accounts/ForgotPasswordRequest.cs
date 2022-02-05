using System.ComponentModel.DataAnnotations;

namespace SJERP.Business.Authentication.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}