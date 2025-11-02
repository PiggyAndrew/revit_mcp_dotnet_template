using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.APP.API.DataModel;

namespace NET.App.API.DataModel
{
    public class GetELementDto
    {
        public  const  string Name  ="GETELEMENT";

        public const string Description = "通过过滤条件获取Revit中的元素。过滤条件Filter可能会有多个，且可以通过其的operator属性关联与或非关系";

        public List<Filter> Filters { get; set; }
    }
}
