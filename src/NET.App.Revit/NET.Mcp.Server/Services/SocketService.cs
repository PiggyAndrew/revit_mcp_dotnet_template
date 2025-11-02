using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NET.Mcp.Server.Services
{
    public class SocketService
    {
        public SocketService() { }

        // Revit Socket服务器配置
        private const string REVIT_SERVER_IP = "127.0.0.1";
        private const int REVIT_SERVER_PORT = 8080;
        private const int SOCKET_TIMEOUT = 30000; // 30秒超时

        /// <summary>
        /// 向Revit发送Socket请求并获取响应
        /// </summary>
        /// <param name="jsonData">要发送的JSON数据</param>
        /// <returns>Revit返回的响应数据</returns>
        public async Task<string> SendToRevitAsync(string jsonData)
        {
            TcpClient client = null;
            try
            {
                // 创建TCP客户端连接
                client = new TcpClient();
                client.ReceiveTimeout = SOCKET_TIMEOUT;
                client.SendTimeout = SOCKET_TIMEOUT;

                // 连接到Revit Socket服务器
                await client.ConnectAsync(REVIT_SERVER_IP, REVIT_SERVER_PORT);
                Console.WriteLine($"Send to revit service {REVIT_SERVER_IP}:{REVIT_SERVER_PORT}");

                // 获取网络流
                NetworkStream stream = client.GetStream();

                // 发送数据到Revit
                byte[] data = Encoding.UTF8.GetBytes(jsonData);
                await stream.WriteAsync(data, 0, data.Length);
                Console.WriteLine("Message has been sended to revit");

                // 读取Revit的响应
                byte[] buffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine("Revit reponse");
                return response;
            }
            catch (SocketException ex)
            {
                string errorMsg = $"Socket error: {ex.Message}. Please keep Revit Socket running。";
                Console.WriteLine(errorMsg);
                return JsonConvert.SerializeObject(new { error = errorMsg });
            }
            catch (Exception ex)
            {
                string errorMsg = $"Error when Send messages to revit : {ex.Message}";
                Console.WriteLine(errorMsg);
                return JsonConvert.SerializeObject(new { error = errorMsg });
            }
            finally
            {
                // 确保客户端连接被正确关闭
                client?.Close();
            }
        }
    }
}
