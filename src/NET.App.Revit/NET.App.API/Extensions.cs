using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace NET.App.API
{
    public static class CommonUtility
    {
        public static string GetEmbeddedText(Assembly baseAssembly, [Localizable(false)] string resourceFile)
        {
            if (resourceFile == null)
            {
                throw new ArgumentNullException("resourceFile");
            }
            using (StreamReader streamReader = new StreamReader(baseAssembly.GetManifestResourceStream(resourceFile) ?? throw new InvalidOperationException("Could not get resource stream located at " + resourceFile + " in assembly " + baseAssembly.FullName)))
            {

                return streamReader.ReadToEnd();
            }
        }

        public static List<string> GetValuesFromEmbeddedTxt(Assembly baseAssembly, [Localizable(false)] string resourceFile)
        {
            if (resourceFile == null)
            {
                throw new ArgumentNullException("resourceFile");
            }
            string embeddedText = GetEmbeddedText(baseAssembly, resourceFile);
            List<string> list = new List<string>();
            using (StringReader stringReader = new StringReader(embeddedText))
            {
                string text;
                while ((text = stringReader.ReadLine()) != null)
                {
                    if (text != "INVALID" && !text.ToLower().Contains("deprecated") && !text.ToLower().Contains("obsolete"))
                    {
                        list.Add(text);
                    }
                }
            }
            list.Sort();
            return list;
        }

        public static void CloneObjectProperties<T>(T source, T target, Dictionary<string, object> overrides = null)
        {
            PropertyInfo[] properties = source.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (propertyInfo.CanWrite)
                {
                    if (overrides != null && overrides.ContainsKey(propertyInfo.Name))
                    {
                        propertyInfo.SetValue(target, overrides[propertyInfo.Name]);
                        continue;
                    }
                    object value = propertyInfo.GetValue(source);
                    propertyInfo.SetValue(target, value);
                }
            }
        }
    }
}
