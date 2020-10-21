using Authorization.Library.Roles;
using Microsoft.AspNetCore.Authorization;

namespace RE.Authorization.Library.Policies
{
    public class RePolicies
    {
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(ReRoles.Admin).Build();
        }
        public static AuthorizationPolicy TeacherPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(ReRoles.Teacher).Build();
        }
        public static AuthorizationPolicy ManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(ReRoles.Manager).Build();
        }
        public static AuthorizationPolicy StudentPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(ReRoles.Student).Build();
        }
    }
}