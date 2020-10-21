using Authorization.Library.Roles;

namespace RemoteEducation.Security
{
    public class Roles
    {
        private const string Separator = ",";
        public const string ScheduleEditor = ReRoles.Manager + Separator + ReRoles.Teacher;
    }
}
