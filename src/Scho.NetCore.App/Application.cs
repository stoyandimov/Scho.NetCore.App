using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Scho.NetCore.App
{
	public class Application
	{
		public static Application Create(string[] args = null)
		{
			return new Application();
		}

		private Application()
		{

		}

		public void Run(Action<IConfiguration, IServiceProvider, ILoggerFactory> runCallback)
		{
			runCallback(
				new ConfigurationRoot(new List<IConfigurationProvider>()),
				ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(new ServiceCollection()),
				new NullLoggerFactory());
		}

	}
}