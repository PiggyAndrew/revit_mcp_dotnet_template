// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NET.Mcp.Server.Extensions;
using NET.Mcp.Server.Tools;

var builder = Host.CreateApplicationBuilder();
builder.Services
    .RegisterServices()
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<DemoTools>();

await builder.Build().RunAsync();

