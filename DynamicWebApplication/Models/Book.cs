using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DynamicWebApplication
{
    [GeneratedController]
    [NavigationMetadata(NavText = "Books", IconCss = "book")]
    public class Book : IStorageEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime Published { get; set; }
    }
}
