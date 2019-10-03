using Xunit;
using Scho.NetCore.App;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Scho.NetCore.AppUTest
{
	public class ApplicationShould
	{
		[Fact]
		public void Create()
		{
			var sut = Application.Create();

			Assert.NotNull(sut);
		}

		[Fact]
		public void RunWithConfiguration()
		{
			IConfiguration config = null;

			Application.Create().Run((cfg, svcs, lf)
				=> config = Assert.IsAssignableFrom<IConfiguration>(cfg));

			Assert.NotNull(config);
		}

		[Fact]
		public void RunWithServices()
		{
			IServiceProvider services = null;

			Application.Create().Run((cfg, svcs, lf)
				=> services = Assert.IsAssignableFrom<IServiceProvider>(svcs));

			Assert.NotNull(services);
		}

		[Fact]
		public void RunWithLogger()
		{
			ILoggerFactory loggerFactory = null;

			Application.Create().Run((cfg, svcs, lf)
				=> loggerFactory = Assert.IsAssignableFrom<ILoggerFactory>(lf));

			Assert.NotNull(loggerFactory);
		}
	}
}
