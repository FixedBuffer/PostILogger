using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PostILogger.Benchmarks
{
    [MemoryDiagnoser]
    public class ILoggerParameters
    {
        private readonly ILogger _logger;
        public ILoggerParameters()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging();

            var loggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();

            _logger = loggerFactory.CreateLogger("TEST");
        }

        [Benchmark(Baseline = true)]
        public void Logger0Parametros()
        {
            _logger.LogInformation("Mensaje de log sin parámetros");
        }

        [Benchmark]
        public void Logger1Parametro()
        {
            _logger.LogInformation("Mensaje de log con un parámetro {Parametro1}", "Valor1");
        }

        [Benchmark]
        public void Logger2Parametros()
        {
            _logger.LogInformation("Mensaje de log con dos parámetros ({Parametro1},{Parametro2})", "Valor1", "Valor2");
        }
    }
}

