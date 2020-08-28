using System;

namespace DynamicWebApplication
{
    [GeneratedController]
    [NavigationMetadata(NavText = "Records", IconCss = "record")]
    public class SomeRecord : IStorageEntity
    {
        public Guid Id { get; set; }

        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
        public string Prop5 { get; set; }
    }
}
