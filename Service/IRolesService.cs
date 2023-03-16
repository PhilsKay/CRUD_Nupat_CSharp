namespace Nupat_CSharp.Service
{
    public interface IRolesService
    {
        Task<string> CreateRole(string roleName);   
        Task<string> AddUserToRole(string user, string roleName);

    }
}
