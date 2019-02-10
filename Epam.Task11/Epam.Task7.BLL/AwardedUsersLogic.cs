using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;
using Epam.Task7.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.BLL
{
    public class AwardedUsersLogic : IAwardedUsersLogic
    {
        private const string ALL_AWARDED_USERS_CACHE_KEY = "GetAllAwardedUsers";
        private readonly IAwardedUsersDao awardedUsersDao;
        private readonly ICacheLogic cacheLogic;

        public AwardedUsersLogic(IAwardedUsersDao awardedUsersDao, ICacheLogic cacheLogic)
        {
            this.awardedUsersDao = awardedUsersDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(int userId, int awardId)
        {
            try
            {
                this.awardedUsersDao.Add(userId, awardId);
                this.cacheLogic.Delete(ALL_AWARDED_USERS_CACHE_KEY);
            }
            catch (CollisionException)
            {
                return;
            }
        }

        public void Delete(int userId, int awardId)
        {
            try
            {
                this.awardedUsersDao.Delete(userId, awardId);
                this.cacheLogic.Delete(ALL_AWARDED_USERS_CACHE_KEY);
            }
            catch (CollisionException)
            {
                return;
            }
        }

        public void DeleteByIdAward(int awardId)
        {
            try
            {
                this.awardedUsersDao.DeleteByIdAward(awardId);
                this.cacheLogic.Delete(ALL_AWARDED_USERS_CACHE_KEY);
            }
            catch (CollisionException)
            {
                return;
            }
        }

        public IEnumerable<AwardedUser> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<AwardedUser>>(ALL_AWARDED_USERS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = this.awardedUsersDao.GetAll();
                this.cacheLogic.Add(ALL_AWARDED_USERS_CACHE_KEY, this.awardedUsersDao.GetAll());
                return result;
            }

            return cacheResult;
        }

        public IEnumerable<User> GetUsersByAwardId(int id, IEnumerable<User> allUsers)
        {
            IEnumerable<AwardedUser> awardedUsers = awardedUsersDao.GetByAwardId(id);
            var users = from us in allUsers
                        join awUs in awardedUsers on us.Id equals awUs.IdUser
                        where awUs.IdAward == id
                        select us;
            return users;
        }

        public IEnumerable<Award> GetAwardsByUserId(int id, IEnumerable<Award> allAwards)
        {
            IEnumerable<AwardedUser> awardedUsers = awardedUsersDao.GetByUserId(id);
            var awards = from aw in allAwards
                        join awUs in awardedUsers on aw.Id equals awUs.IdAward
                        where awUs.IdUser == id
                        select aw;
            return awards;
        }

        public bool AwardConnected(int awardId)
        {
            foreach (var item in this.awardedUsersDao.GetAll())
            {
                if(item.IdAward == awardId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
