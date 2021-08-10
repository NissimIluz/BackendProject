using DALContract;

namespace Contracts
{
    public interface IUserService
    {
        public IDAL Idal { get; set; }
        public bool RegisterUser(string userID, string name);
        public bool Login(string userID, string name);
        public void RegisterGame(int gameToken, string userID, string Username, string botName, string result);
        public bool UserExistsCheck(string userID);
        public bool TokenExist(int token);
    }
}