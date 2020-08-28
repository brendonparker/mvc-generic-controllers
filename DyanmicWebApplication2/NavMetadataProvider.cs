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
                .Where(x => x.GetCustomAttributes(typeof(GeneratedControllerAttribute), false).Any());

            foreach (var candidate in candidates)
            {
                var att = candidate.GetCustomAttribute<GeneratedControllerAttribute>();

                if (!att.ShowInNav) continue;

                var controllerName = candidate.Name;

                yield return new NavMetadata
                {
                    DisplayText = att.NavText ?? controllerName,
                    Controller = controllerName
                };
            }
        }
    }

    public class NavMetadata
    {
        public string Controller { get; set; }
        public string Action { get; set; } = "Index";
        public string DisplayText { get; set; }
    }
}
