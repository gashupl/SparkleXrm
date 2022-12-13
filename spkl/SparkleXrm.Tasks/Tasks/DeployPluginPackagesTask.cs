using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using SparkleXrm.Tasks.Config;

namespace SparkleXrm.Tasks
{
    public class DeployPluginPackagesTask : BaseTask
    {
        public bool ExcludePluginSteps { get; set; }

        public DeployPluginPackagesTask(IOrganizationService service, ITrace trace) : base(service, trace)
        {
        }

        protected override void ExecuteInternal(string folder, OrganizationServiceContext ctx)
        {
            _trace.WriteLine("Searching for plugin config in '{0}'", folder);
            var configs = ServiceLocator.ConfigFileFactory.FindConfig(folder);

            foreach (var config in configs)
            {
                _trace.WriteLine("Using Config '{0}'", config.filePath);
                DeployPackages(ctx, config);
            }
            _trace.WriteLine("Processed {0} config(s)", configs.Count);
        }

        private void DeployPackages(OrganizationServiceContext ctx, ConfigFile config)
        {
        }
    }
}
