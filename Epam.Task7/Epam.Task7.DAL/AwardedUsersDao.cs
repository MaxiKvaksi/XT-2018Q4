using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;
using Epam.Task7.Entities.Exceptions;

namespace Epam.Task7.DAL
{
    public class AwardedUsersDao : IAwardedUsersDao
    {
        private List<AwardedUser> awardedUsers = new List<AwardedUser>();

        public AwardedUsersDao(DataSourceType memory)
        {
            switch (memory)
            {
                case DataSourceType.Memory:
                    break;
                case DataSourceType.File:
                    this.awardedUsers = FileHelper.ReadAwardedUsersData();
                    break;
            }
        }

        public void Add(int userId, int awardId)
        {
            AwardedUser awardedUser = new AwardedUser(userId, awardId);
            if (this.awardedUsers.Contains(awardedUser))
            {
                throw new CollisionException();
            }

            this.awardedUsers.Add(awardedUser);
            FileHelper.WriteAwardedUsersData(this.awardedUsers);
        }

        public IEnumerable<AwardedUser> GetAll()
        {
            return this.awardedUsers;
        }

        public IEnumerable<AwardedUser> GetByAwardId(int id)
        {
            return this.awardedUsers.Where(x => x.IdAward == id);
        }

        public IEnumerable<AwardedUser> GetByUserId(int id)
        {
            return this.awardedUsers.Where(x => x.IdUser == id);
        }
    }
}
