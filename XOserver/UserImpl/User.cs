using FinalExerciseModuleAContracts;
using System;

namespace UserImpl
{
    public class User : Iuser
    {
        string _userId;
        string _userName;
        public User (string id, string name)
        {
            _userId = id;
            _userName = name;
        }
        public string UserId {get {return _userId; } }
        public string UserName {get { return _userName; } }

    }
}
