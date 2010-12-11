using System;

namespace AutoReST.Infrastructure
{
    public static class StringHelpers
    {
        static int _uniqueId;

        public static string GetUniqueString(params string[] baseValues)
        {
            _uniqueId++;
            
            return String.Format("{0}{1}", baseValues, _uniqueId);
        }

        public static string Pluralize(string singular)
        {
            return singular + "s";
        }
    }

}