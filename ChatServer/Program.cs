using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ChatServer
{
    private static List<Socket> clients = new List<Socket>();
    private static readonly object locker = new object();

    static void Main()
    {
        Console.WriteLine("Iniciando servidor...");
        IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 5000);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverSocket.Bind(endpoint);
        serverSocket.Listen(5);

        Console.WriteLine("Servidor iniciado. Esperando conexiones...");
        while (true)
        {
            Socket clientSocket = serverSocket.Accept();
            lock (locker) { clients.Add(clientSocket); }
            Console.WriteLine("Cliente conectado.");
            Thread thread = new Thread(() => HandleClient(clientSocket));
            thread.Start();
        }
    }

    static void HandleClient(Socket clientSocket)
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = clientSocket.Receive(buffer)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Mensaje recibido: {message}");
                BroadcastMessage(message, clientSocket);
            }
        }
        catch
        {
            Console.WriteLine("Cliente desconectado.");
            lock (locker) { clients.Remove(clientSocket); }
        }
    }

    static void BroadcastMessage(string message, Socket sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        lock (locker)
        {
            foreach (Socket client in clients)
            {
                if (client != sender)
                {
                    client.Send(data);
                }
            }
        }
    }
}
