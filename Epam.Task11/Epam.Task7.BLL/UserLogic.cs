using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL
{
    public class UserLogic : IUserLogic
    {
        private const string ALL_USERS_CACHE_KEY = "GetAllUsers";
        private readonly IUserDao userDao;
        private readonly ICacheLogic cacheLogic;      

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            this.userDao = userDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new NullReferenceException("User is null");
                }

                this.userDao.Add(user);
                this.cacheLogic.Delete(ALL_USERS_CACHE_KEY);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            this.userDao.Delete(id);
            this.cacheLogic.Delete(ALL_USERS_CACHE_KEY);
        }

        public IEnumerable<User> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<User>>(ALL_USERS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = this.userDao.GetAll();
                this.cacheLogic.Add(ALL_USERS_CACHE_KEY, this.userDao.GetAll());
                return result;
            }

            return cacheResult;
        }

        public User GetById(int id)
        {
            return userDao.GetById(id);
        }

        public void Update(User user)
        {
            this.userDao.Update(user);
            this.cacheLogic.Delete(ALL_USERS_CACHE_KEY);
        }
    }
}
