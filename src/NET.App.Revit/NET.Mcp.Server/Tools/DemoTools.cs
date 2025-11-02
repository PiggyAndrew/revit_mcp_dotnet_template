using System.ComponentModel;
using System.Text.Json.Serialization;
using ModelContextProtocol.Server;
using NET.App.API.CommandModels;
using NET.App.Revit.Models;
using NET.Mcp.Server.Services;
using Newtonsoft.Json;

namespace NET.Mcp.Server.Tools
{

    [McpServerToolType]
    public class DemoTools
    {
        private SocketService _socketService;

        public DemoTools(SocketService socketService)
        {
            _socketService = socketService;
        }


        [McpServerTool(Name = nameof(CreateWall)), Description("input wall start and end location to create wall in revit")]
        public async Task<string> CreateWall(Create_Wall create_Wall)
        {
            ICommand<Create_Wall> command=new Command<Create_Wall>();
            command.Name=nameof(CreateWall);
            command.Description = "input wall start and end location to create wall in revit";
            command.Parameter = create_Wall;
            //convert to json and send to revit
            var commandJson=JsonConvert.SerializeObject(command);
            string response = await _socketService.SendToRevitAsync(commandJson);

            return response;
        }

    }
}
