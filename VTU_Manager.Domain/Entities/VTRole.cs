using Microsoft.AspNetCore.Identity;

namespace VTU_Manager.Domain.Entities
{
    public class VTRole : IdentityRole<string>
    {
        public VTRole()
        {
            
        }

        public VTRole(string roleName) : base(roleName)
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
