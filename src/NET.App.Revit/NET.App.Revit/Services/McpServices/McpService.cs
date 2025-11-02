using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NET.App.API.CommandModels;
using NET.App.Revit.Models;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using Tuna.Revit.Extensions;
using System.Linq;

namespace NET.App.Revit.Services.McpServices
{
    public class McpService
    {

        public McpService()
        {
        }

       


        public string ProcessCommandAsync(JObject? args)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<Command<Create_Wall>>(args.ToString());
                ElementId wallId = ElementId.InvalidElementId;
                App._externalEvent.PostCommandAsync((uiapp) =>
                {
                    var document = uiapp.ActiveUIDocument.Document;
                    var wall_curve = Line.CreateBound(new XYZ(data.Parameter.Start.X, data.Parameter.Start.Y, data.Parameter.Start.Z),
                       new XYZ(data.Parameter.End.X, data.Parameter.End.Y, data.Parameter.End.Z));
                    var firstLevel = document.GetElements<Level>().FirstOrDefault();
                    document.NewTransaction(() =>
                    {
                        var wall = Wall.Create(document, wall_curve, firstLevel.Id,false);
                        wallId = wall.Id;
                    });
                });
                var result = new Revit_Response(true, "wall result id:" + wallId.ToString());
                var resultStr = JsonConvert.SerializeObject(result);
                return resultStr;
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { error = $"处理命令时出错: {ex.Message}" });
            }
        }


    }
}
