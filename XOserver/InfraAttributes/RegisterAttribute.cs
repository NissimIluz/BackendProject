using System;
using System.Collections.Generic;
using System.Text;

namespace InfraAttributes
{
    public class RegisterAttribute:Attribute
    {
        public RegisterAttribute(Type type)
        {
            InterfaceType = type;
        }
        public Type InterfaceType { get; private set; }
    }
}
