using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Autodesk.Revit.UI;
using NET.App.Revit.Services.McpServices;

namespace NET.App.Revit.Services
{
    public class SocketService
    {

        private static TcpListener _server;
        private static bool _isRunning = false;
        private static Thread _serverThread;


        public void Start()
        {
            if (_isRunning)
            {
                return;

            }
            // 启动服务器
            _isRunning = true;
            _serverThread = new Thread(StartSocketServer);
            _serverThread.IsBackground = true;
            _serverThread.Start();
        }

        private void StartSocketServer()
        {

           
            try
            {
                _server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                _server.Start();

                while (_isRunning)
                {
                    try
                    {
                        // 等待客户端连接
                        TcpClient client = _server.AcceptTcpClient();

                        // 处理请求
                        Task.Run(() => HandleClientRequest(client));
                    }
                    catch (Exception ex)
                    {
                        // 记录异常但继续运行
                        System.Diagnostics.Debug.WriteLine($"Socket服务异常：{ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Socket服务严重错误：{ex.Message}");
                _isRunning = false;
            }
            finally
            {
                if (_server != null)
                {
                    _server.Stop();
                }
            }
        }

        private async void HandleClientRequest(TcpClient client)
        {
            using (client)
            {
                try
                {
                    // 获取网络流
                    NetworkStream stream = client.GetStream();

                    // 读取客户端发送的数据
                    byte[] buffer = new byte[4096];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string requestString = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // 解析请求
                    JObject request = JObject.Parse(requestString);
                    var mcpService = new McpService();
                    // 处理命令并获取响应
                    string response = mcpService.ProcessCommandAsync(request);
                    // 将响应转换为JSON并发送回客户端
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                }
                catch (Exception ex)
                {
                    // 处理异常
                    string errorResponse = JsonConvert.SerializeObject(new { error = ex.Message });
                    byte[] errorData = Encoding.UTF8.GetBytes(errorResponse);
                    client.GetStream().Write(errorData, 0, errorData.Length);
                }
            }
        }

        public static void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                if (_server != null)
                {
                    _server.Stop();
                }
            }
        }
    }
}
