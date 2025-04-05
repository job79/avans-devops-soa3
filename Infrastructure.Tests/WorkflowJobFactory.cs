using Domain.Workflows;
using Infrastructure.Workflows;
using Infrastructure.Workflows.AnalyzeJobs;
using Infrastructure.Workflows.BuildJobs;
using Infrastructure.Workflows.DeployJobs;
using Infrastructure.Workflows.PackageJobs;
using Infrastructure.Workflows.SourceJobs;
using Infrastructure.Workflows.TestJobs;
using Infrastructure.Workflows.UtilityJobs;


namespace Infrastructure.Tests
{
    [TestFixture]
    public class WorkflowJobFactoryTests
    {
        [TestCase("semgrep-analyze", typeof(SemgrepAnalyseJob))]
        [TestCase("sonarcube-analyze", typeof(SonarCubeAnalyzeJob))]
        [TestCase("dotnet-build", typeof(DotnetBuildJob))]
        [TestCase("python-build", typeof(PythonBuildJob))]
        [TestCase("azure-deploy", typeof(AzureDeployJob))]
        [TestCase("netifly-deploy", typeof(NetiflyPackageJob))]
        [TestCase("dotnet-package", typeof(DotnetPackageJob))]
        [TestCase("pip-package", typeof(PipPackageJob))]
        [TestCase("clone-recursive-source", typeof(CloneRecursiveSourceJob))]
        [TestCase("clone-source", typeof(CloneSourceJob))]
        [TestCase("nunit-test", typeof(NUnitTestJob))]
        [TestCase("selenium-test", typeof(SeleniumTestJob))]
        [TestCase("python-utility", typeof(PythonBuildJob))]
        [TestCase("bash-utility", typeof(BashUtilityJob))]
        public void TestCreatingJob(string jobName, Type expectedType)
        {
            // Arrange
            string settings = "settings";
            WorkflowJob? nextJob = null;

            // Act
            var job = WorkflowJobFactory.Create(jobName, settings, nextJob);

            // Assert
            Assert.That(job, Is.InstanceOf(expectedType));
        }

        [Test]
        public void TestCreatingUnknownJob()
        {
            // Arrange
            string jobName = "unknown-job";
            string settings = "some settings";
            WorkflowJob? nextJob = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => WorkflowJobFactory.Create(jobName, settings, nextJob));
        }
    }
}