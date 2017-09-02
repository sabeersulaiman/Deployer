using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdDin.Deployer.Deployer
{
    public class DictionaryDeployerConfiguration : IDeployerConfiguration
    {
		private IConfiguration _configuration;
		public DictionaryDeployerConfiguration(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GetConfiguration(string key)
		{
			var data = _configuration[key] ?? null;
			return data;
		}

		public Boolean HasConfiguration(string key)
		{
			var data = _configuration[key] ?? null;
			return data != null;
		}
    }
}
