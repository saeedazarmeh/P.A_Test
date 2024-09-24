using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using P.A._Entity.Roles.Enums;
using P.A_Contract.EndPoint;
using P.A_Service.Roles.Contracts;
using P.A_Service.Users.Contracts;

namespace P.A_API.Security
{
    //public class PermissionChecker : AuthorizeAttribute, IAsyncAuthorizationFilter
    //{
    //    private UserService _userService;
    //    private RoleRepository _roleRepository;
    //    private readonly Permissions _permission;

    //    public PermissionChecker(Permissions permission)
    //    {
    //        _permission = permission;
    //    }
    //    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //    {
    //        if (HasAllowAnonymous(context))
    //            return;

    //        _userService = context.HttpContext.RequestServices.GetRequiredService<UserService>();
    //        if (context.HttpContext.User.Identity.IsAuthenticated)
    //        {
    //            if (await UserHasPermission(context) == false)
    //            {
    //                context.Result = new ForbidResult();
    //            }
    //        }
    //        else
    //        {
    //            context.Result = new UnauthorizedObjectResult("Unauthorize");
    //        }
    //    }

    //    private bool HasAllowAnonymous(AuthorizationFilterContext context)
    //    {
    //        var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
    //        bool hasAllowAnonymous = false;
    //        foreach (var f in metaData)
    //        {
    //            try
    //            {
    //                hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
    //                if (hasAllowAnonymous)
    //                    break;
    //            }
    //            catch
    //            {
    //                // ignored
    //            }
    //        }

    //        return hasAllowAnonymous;
    //    }
    //    private async Task<bool> UserHasPermission(AuthorizationFilterContext context)
    //    {
    //        var user = await _userService.GetUserWithUserRoles(context.HttpContext.User.GetUserId());
    //        if (user == null)
    //            return false;

    //        var roleIds = user.UserRoles.Select(s => s.Id).ToList();
    //        var roles = await _roleRepository.g();
    //        var userRoles = roles.Where(r => roleIds.Contains(r.RoleId));

    //        return userRoles.Any(r => r.RolePermissions.Contains(_permission.ToString()));
    //    }
    //}
}
