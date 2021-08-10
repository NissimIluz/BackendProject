using System;

namespace CreateGameDTO
{
    public class CreateGameResponseDTO
    {
        int _token;
        string _message;
        public CreateGameResponseDTO (int token, string message)
        {
            _message = message;
            _token = token;
        }
        public int Token { get { return _token; } }
        public string Message { get { return _message; } }
    }
}
