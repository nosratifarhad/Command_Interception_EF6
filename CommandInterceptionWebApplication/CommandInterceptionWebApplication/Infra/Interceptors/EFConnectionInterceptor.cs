using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CommandInterceptionWebApplication.Interceptors
{
    public class EFConnectionInterceptor : DbConnectionInterceptor
    {
        private readonly ILogger _logger;

        public EFConnectionInterceptor(ILogger<EFConnectionInterceptor> logger)
        {
            _logger = logger;
        }

        public override void ConnectionClosed(DbConnection connection, ConnectionEndEventData eventData)
        {
            LogInfo("ConnectionClosed", $"{connection.ConnectionString}{eventData.ToString()}");
            base.ConnectionClosed(connection, eventData);
        }

        public override Task ConnectionClosedAsync(DbConnection connection, ConnectionEndEventData eventData)
        {
            LogInfo("ConnectionClosedAsync", $"{connection.ConnectionString}{eventData.ToString()}");
            return base.ConnectionClosedAsync(connection, eventData);
        }

        public override void ConnectionFailed(DbConnection connection, ConnectionErrorEventData eventData)
        {
            LogInfo("ConnectionFailed", $"{connection.ConnectionString}{eventData.ToString()}");
            base.ConnectionFailed(connection, eventData);
        }

        public override Task ConnectionFailedAsync(DbConnection connection, ConnectionErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            LogInfo("ConnectionFailedAsync", $"{connection.ConnectionString}{eventData.ToString()}");
            return base.ConnectionFailedAsync(connection, eventData, cancellationToken);
        }

        public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
        {
            LogInfo("ConnectionOpened", $"{connection.ConnectionString}{eventData.ToString()}");
            base.ConnectionOpened(connection, eventData);
        }

        public override Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            LogInfo("ConnectionOpenedAsync", $"{connection.ConnectionString}{eventData.ToString()}");
            return base.ConnectionOpenedAsync(connection, eventData, cancellationToken);
        }

        #region Private

        private void LogInfo(string method, string data)
        {
            Console.WriteLine("Intercepted on: {0}: \n\t{1}", method, data);
        }

        private void LogInfo(string method, string data, string exception)
        {
            Console.WriteLine("Intercepted on: {0}: \n\t{1} \n\t{2}", method, data, exception);
        }

        #endregion Private

    }
}
