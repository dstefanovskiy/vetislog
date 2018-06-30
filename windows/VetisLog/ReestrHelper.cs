using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace VetisLog
{
    public class ReestrHelper
    {
        public void Write(string key, object value)
        {
            if (value != null)
            {
                key = (key ?? string.Empty).Trim().ToLowerInvariant();

                var reestrKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VetisLog\VetisLog_Agent");
                reestrKey?.SetValue(key, value);
                reestrKey?.Close();
            }
        }

        public object Read(string key)
        {
            key = (key ?? string.Empty).Trim().ToLowerInvariant();
            var reestrKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\VetisLog\VetisLog_Agent");
            var result = reestrKey?.GetValue(key);
            reestrKey?.Close();
            return result;
        }
    }
}