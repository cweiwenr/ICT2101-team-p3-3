﻿using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Thread t = new Thread(delegate ()
        {
            // change ip to ur com's private ip
            Server myserver = new Server("192.168.157.22", 5000);
        });
        t.Start();
        
        Console.WriteLine("Server Started...!");
    }
}