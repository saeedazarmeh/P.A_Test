namespace P.A_Service.Roles.Contracts.DTO.Roles;

public class RoleResultDTO
{
    public int RoleId { get; set; }
    public string Title { get; set; }
    public List<string> RolePermissions { get; set; }
}