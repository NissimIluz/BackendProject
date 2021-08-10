using Contracts;
using DALImpl;
using DALContract;
using System;
using InfraAttributes;

namespace UserServiceImpl
{
    [Register(typeof(IUserService))]
    [Policy(Policy.Singleton)]
    public class UserService : IUserService
    {

        public UserService() { }
        public IDAL Idal { get; set; }
        public bool RegisterUser(string userID, string name)
        {
            var paramUserID = Idal.CreateParameter("userID", userID);
            var paramUserName = Idal.CreateParameter("userName", name);
            var dataSet = Idal.ExecuteQuery("AddUser", paramUserID, paramUserName);
            return (dataSet.Tables.Count == 0);
        }
        public bool Login(string userID, string name)
        {
            var paramUserID = Idal.CreateParameter("userID", userID);
            var paramUserName = Idal.CreateParameter("userName", name);
            var dataSet = Idal.ExecuteQuery("UserEnter", paramUserID, paramUserName);
            return (dataSet.Tables[0].Rows.Count == 1);

        }
        public bool UserExistsCheck(string userID)
        {
            var paramUserID = Idal.CreateParameter("UserID", userID);
            var dataset = Idal.ExecuteQuery("UserExistsCheck", paramUserID);
            return (dataset.Tables[0].Rows.Count == 1);
        }
        public void RegisterGame(int gameToken, string userID, string Username, string botName, string result)
        {
            var paramUserToken = Idal.CreateParameter("gameToken", gameToken);
            var paramUserID = Idal.CreateParameter("userID", userID);
            var paramUserName = Idal.CreateParameter("username", Username);
            var paramUserBot = Idal.CreateParameter("bot", botName);
            var paramUserResult = Idal.CreateParameter("result", result);
            Idal.ExecuteNonQuery("RegisterGame", paramUserToken, paramUserID, paramUserName, paramUserBot, paramUserResult);
        }
        public bool TokenExist(int token)
        {
            var paramUserToken = Idal.CreateParameter("token", token);
            var dataset = Idal.ExecuteQuery("TokenExist", paramUserToken);
            return (dataset.Tables[0].Rows.Count == 1);

        }
    }
}
