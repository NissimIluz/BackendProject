
using InfraAttributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DynamicLoaderComponent
{
    public class LoadServicesClass
    {
        public void LoadServices(string path, IServiceCollection servise)
        {
            var servicePath = (path);
            var files = Directory.GetFiles(servicePath, "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFrom(file);
                foreach (var type in assembly.GetTypes())
                {
                    var policyAttribute = type.GetCustomAttribute<PolicyAttribute>();
                    var registerAttribute = type.GetCustomAttribute<RegisterAttribute>();
                    if (registerAttribute != null)
                    {
                        if (policyAttribute!= null && policyAttribute.Policy == Policy.Singleton)
                        {
                            servise.AddSingleton(registerAttribute.InterfaceType, type);
                        }
                        else
                            servise.AddTransient(registerAttribute.InterfaceType, type);

                    }
                }
            }
        }
    }
}