﻿using SimpleTCPPlus.Server;
using System;
using System.Threading;

namespace ReallyServer
{
    class Server
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server started");
            var server = new SimpleTcpServer(System.Reflection.Assembly.GetExecutingAssembly()).Start(6124);
            server.DataReceived += (s, pack) =>
            {
                Console.WriteLine($"PACKET:\n{pack.Packet.PacketType}");
                server.PacketHandler(pack);
            };
            new Thread(() => { while (true) { } }).Start();
        }
    }
}
