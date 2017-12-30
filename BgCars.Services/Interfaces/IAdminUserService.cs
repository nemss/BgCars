namespace BgCars.Services.Interfaces
{
    using Models.Admin;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();

        Task DeleteAsync(string userId);
    }
}
