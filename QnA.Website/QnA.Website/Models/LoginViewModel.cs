using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace QnA.Website.Models
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public IEnumerable<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
