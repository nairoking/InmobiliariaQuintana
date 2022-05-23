using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InmobiliariaQuintana
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//En visual studio este el "run" recomendado:
			CreateWebHostBuilder(args).Build().Run();
			//En VS Code este otro es el "run" recomendado:
			//CreateKestrel(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			var host = WebHost.CreateDefaultBuilder(args)
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();//limpia los proveedores x defecto de log (consola+depuraci�n)
					logging.AddConsole();//agrega log de consola
										 //logging.AddConfigur(new LoggerConfiguration().WriteTo.File("serilog.txt").CreateLogger())
				})
				.UseStartup<Startup>();
			return host;
		}

		public static IWebHostBuilder CreateKestrel(string[] args)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.Build();
			var host = new WebHostBuilder()
				.UseConfiguration(config)
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				//.UseUrls("http://localhost:5000", "https://localhost:5001")//permite escuchar SOLO peticiones locales
				.UseUrls("http://*:5000", "https://*:5001")//permite escuchar peticiones locales y remotas
				.UseIISIntegration()
				.UseStartup<Startup>();
			return host;
		}
	}
}
