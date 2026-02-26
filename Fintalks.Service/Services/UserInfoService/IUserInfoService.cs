using Fintalks.DB.DBEntity;

namespace Fintalks.Service.Services.UserInfoService
{
    public interface IUserInfoService
    {
        public Task<DBUserInfo> GetUserInfoByID(int DBUserID);
    }
}
