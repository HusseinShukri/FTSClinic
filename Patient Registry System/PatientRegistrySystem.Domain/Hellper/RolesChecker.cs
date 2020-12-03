using PatientRegistrySystem.Domain.Roles;

namespace PatientRegistrySystem.Domain.Hellper
{
    public static class RolesChecker
    {
        public static bool IsValedRole(this string value)
        {
            if (value.Equals(UserRoles.Admin))
            {
                return true;
            }
            else if (value.Equals(UserRoles.Doctor))
            {
                return true;
            }
            else if (value.Equals(UserRoles.Employee))
            {
                return true;
            }
            else if (value.Equals(UserRoles.Patient))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
