using System;
using System.Configuration;
using Epam.Task7.BLL;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL;
using Epam.Task7.DAL.Interface;

namespace Epam.Task7.Common
{
    public class DependencyResolver
    {
        private static IUserDao userDao;
        private static IUserLogic userLogic;
        private static IAwardDao awardDao;
        private static IAwardLogic awardLogic;
        private static IAwardedUsersDao awardedUsersDao;
        private static IAwardedUsersLogic awardedUsersLogic;
        private static ICacheLogic cacheLogic;

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic));

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDao, CacheLogic));

        public static IAwardedUsersLogic AwardedUsersLogic => awardedUsersLogic ?? (awardedUsersLogic = new AwardedUsersLogic(AwardedUsersDao, CacheLogic));

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoDataKey"];

                if (userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                userDao = new UserDao(DataSourceType.Memory);
                                break;
                            }

                        case "file":
                            {
                                userDao = new UserDao(DataSourceType.File);
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return userDao;
            }
        }

        public static IAwardDao AwardDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoDataKey"];

                if (awardDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                awardDao = new AwardDao(DataSourceType.Memory);
                                break;
                            }

                        case "file":
                            {
                                awardDao = new AwardDao(DataSourceType.File);
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return awardDao;
            }
        }

        public static IAwardedUsersDao AwardedUsersDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoDataKey"];

                if (awardedUsersDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                awardedUsersDao = new AwardedUsersDao(DataSourceType.Memory);
                                break;
                            }

                        case "file":
                            {
                                awardedUsersDao = new AwardedUsersDao(DataSourceType.File);
                                break;
                            }

                        default:
                            throw new Exception("Invalid app data source configuration");
                    }
                }

                return awardedUsersDao;
            }
        }
    }
}
