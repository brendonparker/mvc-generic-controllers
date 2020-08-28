using System;

namespace DynamicWebApplication
{
    [GeneratedController]
    [NavigationMetadata(NavText = "People", IconCss = "user")]
    public class Person : IStorageEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
