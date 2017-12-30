namespace BgCars.Services.Implementations.Admin
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models.Admin;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly BgCarsDbContext db;

        public AdminUserService(BgCarsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
                .Users
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();

        public async Task DeleteAsync(string userId)
        {
            var findUserById = await this.db.Users.FindAsync(userId);

            if (findUserById == null)
            {
                return;
            }

            this.db.Users.Remove(findUserById);
            await this.db.SaveChangesAsync();
        }
    }
}
