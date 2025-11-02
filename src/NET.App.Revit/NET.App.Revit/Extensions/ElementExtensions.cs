using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.App.Revit.Extensions
{
    public  static class ElementExtensions
    {

        public static long GetIdNumericValue(this ElementId id)
        {
            return id.IntegerValue;
        }

        public static string GetIdStringValue(this ElementId id)
        {
            return id.GetIdNumericValue().ToString();
        }

        public static long GetBicNumericValue(this BuiltInCategory source)
        {
            return (long)source;
        }

        public static BuiltInCategory GetBuiltInCategoryObject(this long id)
        {
            return (BuiltInCategory)id;
        }

    }
}
