using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using NET.App.Revit.Services;
using System;
using Tuna.Revit.Extensions;

namespace NET.App.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    [CommandButton(Title = "Stop")]
    public class StopSocketServerCommand : IExternalCommand
    {

      

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                // 调用静态方法停止服务
                SocketService.Stop();
                TaskDialog.Show("Revit Socket服务", "Revit Socket服务已停止");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("错误", $"停止Socket服务失败：{ex.Message}");
                return Result.Failed;
            }
        }
    }
}