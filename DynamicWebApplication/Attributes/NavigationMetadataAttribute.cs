using System;

namespace DynamicWebApplication
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NavigationMetadataAttribute : Attribute
    {
        public string NavText { get; set; }
        public string IconCss { get; set; }
        public int SortOrder { get; set; } = 100;
    }
}
