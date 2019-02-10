using Epam.Task7.BLL.Interface;
using Epam.Task7.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.Task11.WebUsersAndAwards.RoleProviderFolder
{
    public class MyRoleProvider : RoleProvider
    {
        IUserLogic userLogic = DependencyResolver.UserLogic;

        public override bool IsUserInRole(string username, string roleName)
        {
            if(GetRolesForUser(username).Contains(roleName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if(username == "admin")
            {
                return new[] { "admins", "users" };
            }
            else
            {
                if(username != "")
                {
                    foreach (var item in userLogic.GetAll())
                    {
                        if(item.Name == username)
                        {
                            return new[] { "users" };
                        }
                    }
                }
                return new[] { "guest" };
            }
            /*switch (username)
            {
                case "admin":
                    return new[] { "admins", "users" };
                default:
                    return new[] { "users" }; 
            }*/
        }

        #region NotImplemented
        

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

    

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}