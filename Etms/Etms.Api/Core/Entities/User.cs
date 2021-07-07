using Etms.Api.Core.Entities.Base;

namespace Etms.Api.Core.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        
        // Not mapped property
        public string Token { get; set; }
    }
}