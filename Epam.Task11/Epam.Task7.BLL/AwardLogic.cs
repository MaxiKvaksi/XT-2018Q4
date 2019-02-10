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
    public class AwardLogic : IAwardLogic
    {
        private const string ALL_AWARDS_CACHE_KEY = "GetAllAwards";
        private readonly IAwardDao awardsDao;
        private readonly ICacheLogic cacheLogic;      

        public AwardLogic(IAwardDao awardsDao, ICacheLogic cacheLogic)
        {
            this.awardsDao = awardsDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(Award award)
        {
            try
            {
                if (award == null)
                {
                    throw new NullReferenceException("User is null");
                }

                this.awardsDao.Add(award);
                this.cacheLogic.Delete(ALL_AWARDS_CACHE_KEY);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            this.awardsDao.Delete(id);
            this.cacheLogic.Delete(ALL_AWARDS_CACHE_KEY);
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = this.cacheLogic.Get<IEnumerable<Award>>(ALL_AWARDS_CACHE_KEY);

            if (cacheResult == null)
            {
                var result = this.awardsDao.GetAll();
                this.cacheLogic.Add(ALL_AWARDS_CACHE_KEY, this.awardsDao.GetAll());
                return result;
            }

            return cacheResult;
        }

        public Award GetById(int id)
        {
            return this.awardsDao.GetById(id);
        }

        public void Update(Award award)
        {
            this.awardsDao.Update(award);
            this.cacheLogic.Delete(ALL_AWARDS_CACHE_KEY);
        }
    }
}
