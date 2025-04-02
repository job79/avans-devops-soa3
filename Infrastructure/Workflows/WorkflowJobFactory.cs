using Domain.Workflows;
using Infrastructure.Workflows.AnalyzeJobs;
using Infrastructure.Workflows.BuildJobs;
using Infrastructure.Workflows.DeployJobs;
using Infrastructure.Workflows.PackageJobs;
using Infrastructure.Workflows.SourceJobs;
using Infrastructure.Workflows.TestJobs;
using Infrastructure.Workflows.UtilityJobs;

namespace Infrastructure.Workflows;

public class WorkflowJobFactory
{
    public static WorkflowJob Create(string name, string settings, WorkflowJob? nextJob)
    {
        switch (name)
        {
            case "semgrep-analyze":
                return new SemgrepAnalyseJob(settings, nextJob);
            case "sonarcube-analyze":
                return new SonarCubeAnalyzeJob(settings, nextJob);
            
            case "dotnet-build":
                return new DotnetBuildJob(settings, nextJob);
            case "python-build":
                return new PythonBuildJob(settings, nextJob);
            
            case "azure-deploy":
                return new AzureDeployJob(settings, nextJob);
            case "netifly-deploy":
                return new NetiflyPackageJob(settings, nextJob);
            
            case "dotnet-package":
                return new DotnetPackageJob(settings, nextJob);
            case "pip-package":
                return new PipPackageJob(settings, nextJob);
           
            case "clone-recursive-source":
                return new CloneRecursiveSourceJob(settings, nextJob);
            case "clone-source":
                return new CloneSourceJob(settings, nextJob);
            
            case "nunit-test":
                return new NUnitTestJob(settings, nextJob);
            case "selenium-test":
                return new SeleniumTestJob(settings, nextJob);
            
            case "python-utility":
                return new PythonBuildJob(settings, nextJob);    
            case "bash-utility":
                return new BashUtilityJob(settings, nextJob);
            default:
                throw new ArgumentException($"Unknown workflow: {name}");
        }
    }
}