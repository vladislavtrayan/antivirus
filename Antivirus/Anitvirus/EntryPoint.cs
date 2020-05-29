using System;
using Antivirus.GUI;
using Antivirus.Scanner;
using Antivirus.Scanner.Service;
using DataSourceAccess;
using Gtk;
using Microsoft.Extensions.DependencyInjection;

namespace Anitvirus
{
    static class EntryPoint
    {
        public static void Main(string[] args)
        {
            
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDataAccessServiceCollection()
                .AddInternalServices()
                .BuildServiceProvider();
            
            new MainWindow(serviceProvider.GetService<ISignatureRepository>(),
                serviceProvider.GetService<IScannerService>());
            Application.Run();
        }
    }
}