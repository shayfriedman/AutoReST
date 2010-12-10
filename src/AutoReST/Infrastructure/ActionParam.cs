using System;

namespace AutoReST.Infrastructure
{
    public class ActionParam
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public bool IsComplexType { get; set; }
    }
}