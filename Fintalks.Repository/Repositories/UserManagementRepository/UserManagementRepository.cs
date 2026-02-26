using Fintalks.Common.Commands;
using Fintalks.DB;
using Fintalks.DB.DBEntity;

namespace Fintalks.Repository.Repositories.UserManagementRepository
{
    public class UserManagementRepository(
        ApplicationDBContext _context,
        IUserInfoRepository _userInfoRepository,
        IUserRepository _userRepository
    ) : IUserManagementRepository
    {
        public async Task<bool> RegisterUser(DBUser dbUser, DBUserInfo dbUserInfo)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var newUser = await _userRepository.CreateUser(dbUser);
                dbUserInfo.User = newUser;
                var newUserInfo = await _userInfoRepository.CreateUserInfo(dbUserInfo);
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> UpdateUserProfile(DBUser updateUser, DBUserInfo updateUserInfo)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var updatedUser = await _userRepository.UpdateUser(updateUser);
                var result = await _userInfoRepository.UpdateUserInfo(updateUserInfo);
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
