using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.App.Revit.Extensions.List
{

   
    internal class ElementComparerID : IEqualityComparer<Element>
        {
            public bool Equals(Element x, Element y)
            {
                return ((x != null) ? new long?(x.Id.GetIdNumericValue()) : ((long?)null)) == ((y != null) ? new long?(y.Id.GetIdNumericValue()) : ((long?)null));
            }

            public int GetHashCode(Element obj)
            {
                return (int)obj.Id.GetIdNumericValue();
            }
        }
}
