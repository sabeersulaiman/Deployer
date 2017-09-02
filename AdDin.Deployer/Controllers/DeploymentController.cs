using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdDin.Deployer.Deployer;

namespace AdDin.Deployer.Controllers
{
	[Route("api/[controller]")]
    public class DeploymentController : Controller
    {
		private IDeployer _deployer;
		private IDeployerConfiguration _deployerConfiguration;
		public DeploymentController(IDeployer deployer, IDeployerConfiguration deployerConfiguration)
		{
			_deployer = deployer;
			_deployerConfiguration = deployerConfiguration;
		}

		[HttpGet, Route("{secret}")]
		public async Task<IActionResult> Index(string secret)
		{
			if(_deployerConfiguration.HasConfiguration("DEPLOYMENT_SCRIPT_PATH") && _deployerConfiguration.HasConfiguration("DEPLOYMENT_AUTHENTICATOR_STRING"))
			{
				var corSecret = _deployerConfiguration.GetConfiguration("DEPLOYMENT_AUTHENTICATOR_STRING");

				if (secret != corSecret)
				{
					return Unauthorized();
				}
				string s = _deployer.Deploy();
				return new ObjectResult(s);
			}
			else
			{
				return new ObjectResult("Invalid configuration settings.");
			}
		}
    }
}
