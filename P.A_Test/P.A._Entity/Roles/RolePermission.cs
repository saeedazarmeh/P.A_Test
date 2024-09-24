using P.A._Entity.Roles.Enums;

namespace P.A._Entity.Roles;

public class RolePermission
{
    public int Id { get; private set; }
    public Permissions Permission { get; private set; }
    public int RoleId { get; private set; }
    public virtual Role Role { get; private set; }

    public RolePermission(Permissions permission)
    {
        Permission = permission;
    }
}