﻿using System;
using Microsoft.Extensions.Logging;

namespace PostILogger.Optimized
{
    public static class OptimizedLogger
    {
        public static void LogInformation(ILogger logger) => _informationSinParametros(logger, null);
        public static void LogInformation(ILogger logger,string parametro1) => _information1Parametro(logger,parametro1, null);
        public static void LogInformation(ILogger logger, string parametro1, string parametro2) => _information2Parametros(logger,parametro1,parametro2, null);


        private static readonly Action<ILogger, Exception> _informationSinParametros = LoggerMessage.Define(
            LogLevel.Information,
            Events.Evento1,
            "Mensaje de log sin parámetros");

        private static readonly Action<ILogger,string, Exception> _information1Parametro = LoggerMessage.Define<string>(
            LogLevel.Information,
            Events.Evento1,
            "Mensaje de log con 1 parámetro: {Parametro1}");

        private static readonly Action<ILogger,string,string, Exception> _information2Parametros = LoggerMessage.Define<string,string>(
            LogLevel.Information,
            Events.Evento1,
            "Mensaje de log con 2 parámetros: {Parametro1} y {Parametro2}");
    }
}
