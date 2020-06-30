using System;

namespace QnA.Domain.Common
{
    public class ApplicationUser
    {
        protected ApplicationUser()
        {
        }

        public ApplicationUser(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public Guid Id { get; protected set; }
        public string FullName { get; protected set; }
        public string Email { get; protected set; }
    }
}
