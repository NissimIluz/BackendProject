using Contracts;
using System;

namespace GamePlayDTO
{
    public class PlayResponseDTO
    {
        public string Message { get; set; }

        public XorO[][] RetBoard { get; set; }
        public bool Succeed { get; set; }
        public Status Status { get; set; }
    }
}