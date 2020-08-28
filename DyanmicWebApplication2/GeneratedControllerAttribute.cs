﻿using System;

namespace DynamicWebApplication
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public string Route { get; set; }
        public bool ShowInNav { get; set; } = true;
        public string NavText { get; set; }
    }
}
