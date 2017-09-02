using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdDin.Deployer.Deployer
{
    public interface IDeployerConfiguration
    {
		string GetConfiguration(string key);
		Boolean HasConfiguration(string key);
    }
}
