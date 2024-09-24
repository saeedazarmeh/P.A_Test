using System.ComponentModel.DataAnnotations;

namespace P.A_Service.Roles.Contracts.DTO.Roles
{
    public class UpdateRoleDTO
    {
        public UpdateRoleDTO(int roleId, string title)
        {
            RoleId = roleId;
            Title = title;
        }

        public int RoleId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Role size is 50 charector")]
        public string Title { get; set; }
    }
}
