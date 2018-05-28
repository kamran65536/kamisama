using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Build.Definition;
using Microsoft.Build.Evaluation;

namespace KamiSama.Cli
{
	[Cmdlet(VerbsCommon.Get, "ProjectVersion")]
	public class GetProjectVersionCommand : PSCmdlet
	{
		[Parameter(Position = 1, HelpMessage = "Project or nuget file path", Mandatory = true)]
		public string ProjectPath { get; set; }

		public GetProjectVersionCommand()
		{
		}

		protected override void EndProcessing()
		{
			try
			{
				var dir = new DirectoryInfo(ProjectPath);

				if (!dir.Exists)
				{
					this.WriteObject($"Directory does not exist: {ProjectPath}");

					return;
				}

				var projectFile = dir.GetFiles("*.csproj", SearchOption.TopDirectoryOnly).FirstOrDefault();

				this.WriteObject(GetProjectVersion(projectFile));

				base.EndProcessing();
			}
			catch (Exception exp)
			{
				this.WriteObject("**** " + exp.Message + "\r\n" + exp.StackTrace);
			}
		}

		private string GetProjectVersion(FileInfo projectFile)
		{
			var project = Project.FromFile(projectFile.FullName, new ProjectOptions { });

			return project.GetPropertyValue("Version") ?? "1.0.0";
		}
	}
}
