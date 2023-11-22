using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
namespace TestClient.ServerProvider
{ 

    internal class ServerDataStream
    {
        public static async Task<string> ServerDataStreamJson(Object o)
        {
            string dataString = JsonConvert.SerializeObject(o);
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ServerConfig.serverAdress), ServerConfig.serverPort);
                using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                await socket.ConnectAsync(IPAddress.Parse(ServerConfig.serverAdress), ServerConfig.serverPort);
                using var stream = new NetworkStream(socket);
                // кодируем его в массив байт
                var data = Encoding.UTF8.GetBytes(dataString);
                // отправляем массив байт на сервер 
                await stream.WriteAsync(data, 0, data.Count());
                while (true)
                {
                    // буфер для получения данных
                    var responseData = new byte[socket.ReceiveBufferSize];
                    // получаем данные
                    var bytes = await stream.ReadAsync(responseData, 0, responseData.Count());
                    // преобразуем полученные данные в строку
                    string response = Encoding.UTF8.GetString(responseData, 0, responseData.Count());
                    return response;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе: " + ex.Message.ToString());
                return null;
            }
        }
    }
}
