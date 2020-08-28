using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DynamicWebApplication
{
    public class NavMetadataProvider
    {
        public static IEnumerable<NavMetadata> GetNavMetadata()
        {
            var currentAssembly = typeof(NavMetadataProvider).Assembly;
            var candidates = currentAssembly.GetExportedTypes()
                .Select(x => (
                    x.GetCustomAttribute<GeneratedControllerAttribute>(),
                    x.GetCustomAttribute<NavigationMetadataAttribute>(),
                    x.Name
                ))
                .Where(x => x.Item1 != null && x.Item2 != null)
                .OrderBy(x => x.Item2.SortOrder);

            foreach (var (attController, attNavMetadata, controllerName) in candidates)
            {
                yield return new NavMetadata
                {
                    DisplayText = attNavMetadata.NavText ?? controllerName,
                    Controller = controllerName,
                    IconCss = attNavMetadata.IconCss
                };
            }
        }
    }

    public class NavMetadata
    {
        public string Controller { get; set; }
        public string Action { get; set; } = "Index";
        public string DisplayText { get; set; }
        public string IconCss { get; set; }
    }
}
