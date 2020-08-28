using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicWebApplication
{
    [GeneratedController(NavText = "Books")]
    public class Book : IStorageEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime Published { get; set; }
    }
}
