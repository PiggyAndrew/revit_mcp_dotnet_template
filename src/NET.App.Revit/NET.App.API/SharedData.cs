using NET.App.API.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace NET.App.API
{
    internal class SharedData
    {

        static SharedData()
        {
            CategoryDataObjects = GetCategories();
            BuiltInCategoryValues = (from x in CategoryDataObjects
                                     where !string.IsNullOrEmpty(x.BICValue)
                                     select x.BICValue).ToList();
        }

        /// <summary>
        /// All categories as <see cref="T:ADSK.AIT.ModelChecker.API.DataModel.CategoryData" /> objects
        /// </summary>
        public static List<CategoryData> CategoryDataObjects { get; }

        public static List<string> BuiltInCategoryValues { get; }
        private static List<CategoryData> GetCategories()
        {
            string text = typeof(SharedData).Namespace + ".Resources.CategoryReference_" + Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName + ".csv";
            if (!Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(text))
            {
                text = typeof(SharedData).Namespace + ".Resources.CategoryReference.csv";
            }
            List<string> valuesFromEmbeddedTxt = CommonUtility.GetValuesFromEmbeddedTxt(typeof(SharedData).Assembly, text);
            List<CategoryData> list = new List<CategoryData>();
            foreach (string item2 in valuesFromEmbeddedTxt)
            {
                string[] array = item2.Split(',');
                if (!string.IsNullOrEmpty(array[0]))
                {
                    string bicValue = array[0];
                    string parentName;
                    string name;
                    if (array[1].Contains(':'))
                    {
                        string[] array2 = array[1].Split(':');
                        parentName = array2[0].Trim();
                        name = array2[1].Trim();
                    }
                    else
                    {
                        parentName = string.Empty;
                        name = array[1];
                    }
                    CategoryData item = (string.IsNullOrEmpty(array[2]) ? new CategoryData(bicValue, name, parentName, architectural: false, structural: false, mep: false, annotative: false, datum: false, view: false) : new CategoryData(bicValue, name, parentName, array[2].Contains("AR"), array[2].Contains("ST"), array[2].Contains("ME"), array[2].Contains("AN"), array[2].Contains("DA"), array[2].Contains("VW")));
                    list.Add(item);
                }
            }
            return list;
        }

    }
}
