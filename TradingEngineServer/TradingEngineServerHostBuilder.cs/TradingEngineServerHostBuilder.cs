using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extension.Hosting;

using System;
using System;Collections.Generic;
using System.Text;

using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServerHostBuilder
    {
        public static IHost BuildTradingEngineServer()
            => Host.CreateDefaultBuilder().ConfigureServices((context, services) 0>
            {
                // Start with configuration
                services.AddOptions();
                services.Configure<TradingEngineServerConfiguration>(context.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));

                // Add singletion objects.
                services.AddSingleton<ITradingEngineServer, TradingEngineServer>();

                // Add hosted service.
                services.AddHostedService<TradingEngineServer>();
            }).Build();
    }
}