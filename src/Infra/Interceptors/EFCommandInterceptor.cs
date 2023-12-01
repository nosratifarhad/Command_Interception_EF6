using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Text;

namespace CommandInterceptionWebApplication.Infra.Interceptors
{
    public class EFCommandInterceptor : DbCommandInterceptor
    {
        private readonly ILogger _logger;

        public EFCommandInterceptor(ILogger<EFCommandInterceptor> logger)
        {
            _logger = logger;
        }

        public override DbCommand CommandCreated(CommandEndEventData eventData, DbCommand result)
        {
            Log("CommandCreated", eventData, result);
            return base.CommandCreated(eventData, result);
        }

        public override Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            Log("CommandFailedAsync", command, eventData);
            return base.CommandFailedAsync(command, eventData, cancellationToken);
        }

        public override void CommandFailed(DbCommand command, CommandErrorEventData eventData)
        {
            Log("CommandFailed", command, eventData);
            base.CommandFailed(command, eventData);
        }

        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            Log("NonQueryExecuted", command, eventData);
            return base.NonQueryExecuted(command, eventData, result);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            Log("ReaderExecuted", command, eventData);
            return base.ReaderExecuted(command, eventData, result);
        }

        //public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        //{
        //    //if (command.CommandText.StartsWith("-- Get_Daily_Message", StringComparison.Ordinal)
        //    //    && !(result is CachedDailyMessageDataReader))
        //    //{
        //    //    try
        //    //    {
        //    //        await result.ReadAsync(cancellationToken);

        //    //        lock (_lock)
        //    //        {
        //    //            _id = result.GetInt32(0);
        //    //            _message = result.GetString(1);
        //    //            _queriedAt = DateTime.UtcNow;
        //    //            return new CachedDailyMessageDataReader(_id, _message);
        //    //        }
        //    //    }
        //    //    finally
        //    //    {
        //    //        await result.DisposeAsync();
        //    //    }
        //    //}
        //    Log("ValueTask ReaderExecutingAsync", eventData,command);

        //    return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        //}

        #region Private

        private void Log(string method, DbCommand dbCommand, CommandExecutedEventData executedEventData)
        {
            _logger.LogInformation(
                string.Format("Intercepted on: {0} , Database call {1}",
                method, dbCommand.Connection.DataSource));
        }

        private void Log(string method, DbCommand dbCommand, CommandErrorEventData commandError)
        {
            _logger.LogInformation(
                string.Format("Intercepted on: {0} , Database call {1}",
                method, dbCommand.Connection.DataSource));
        }

        private void Log(string method, CommandEndEventData commandEnd, DbCommand dbCommand)
        {
            _logger.LogInformation(
                string.Format("Intercepted on: {0} , Database call {1}",
                method, dbCommand.Connection.DataSource));
        }

        private void Log(string method, CommandEventData commandEnd, DbCommand dbCommand)
        {
            _logger.LogInformation(
                string.Format("Intercepted on: {0} , Database call {1}",
                method, dbCommand.Connection.DataSource));
        }

        #endregion Private

    }
}
