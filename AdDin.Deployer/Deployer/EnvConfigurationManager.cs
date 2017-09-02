using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdDin.Deployer.Deployer
{
    public class EnvConfigurationManager : IDeployerConfiguration
    {
		public string GetConfiguration(string key)
		{
			string value = Environment.GetEnvironmentVariable(key);
			return value;
		}

		public Boolean HasConfiguration(string key)
		{
			return Environment.GetEnvironmentVariable(key) != null;
		}
    }
}
