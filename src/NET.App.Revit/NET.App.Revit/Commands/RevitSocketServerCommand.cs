using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using NET.App.Revit.Services;
using NET.App.Revit.Services.McpServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Tuna.Revit.Extensions;

namespace NET.App.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    [CommandButton(Title = "Start")]
    public class RevitSocketServerCommand : IExternalCommand
    {
        private static SocketService _socketService = new SocketService();


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                if (_socketService != null)
                {
                    _socketService.Start();
                    TaskDialog.Show("提示", $"启动Socket成功");
                }
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("错误", $"启动Socket服务失败：{ex.Message}");
                return Result.Failed;
            }
        }
    }
}