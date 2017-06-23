namespace Server
{
    using IdentityServer3.Core.Models;
    using Microsoft.Owin.FileSystems;
    using Microsoft.Owin.Hosting;
    using Microsoft.Owin.StaticFiles;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IdentityServer v3 SelfHost";
            //https://www.scottbrady91.com/Identity-Server/Getting-Started-with-IdentityServer-4
            //https://www.codeproject.com/Articles/1163131/IdentityServer-WebAPI-MVC-Asp-Net-Identity-Specflo

            const string url = "http://localhost:3333";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server listening at {0}. Press a key to stop", url);
                Console.ReadKey();
            }
        }
    }
}
