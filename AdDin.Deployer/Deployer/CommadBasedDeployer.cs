using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdDin.Deployer.Deployer
{
    public class CommadBasedDeployer : IDeployer
    {
		private IDeployerConfiguration _deployerConfiguration;

		public CommadBasedDeployer(IDeployerConfiguration deployerConfiguration)
		{
			_deployerConfiguration = deployerConfiguration;
		}

		public string Deploy()
		{
			var depScript = _deployerConfiguration.GetConfiguration("DEPLOYMENT_SCRIPT_PATH");
			if (depScript == null) return "The script path is not found.";

			Process cmd = new Process();
			cmd.StartInfo.FileName = @"C:\Users\sabee\Program Files\Git\etc";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.Start();

			cmd.StandardInput.WriteLine(depScript);
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			cmd.WaitForExit();
			return (cmd.StandardOutput.ReadToEnd());
		}
    }
}
