using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CommandInterceptionWebApplication.Infra.Interceptors;

public class EFTransactionInterceptor: DbTransactionInterceptor
{

    private readonly ILogger _logger;

    public EFTransactionInterceptor(ILogger<EFTransactionInterceptor> logger)
    {
        _logger = logger;
    }

    public override InterceptionResult<DbTransaction> TransactionStarting(DbConnection connection, TransactionStartingEventData eventData, InterceptionResult<DbTransaction> result)
    {
        LogInfo("TransactionStarting", $"{connection.ConnectionString}{eventData.ToString()}");
        return base.TransactionStarting(connection, eventData, result);
    }

    public override DbTransaction TransactionStarted(DbConnection connection, TransactionEndEventData eventData, DbTransaction result)
    {
        LogInfo("TransactionStarted", $"{connection.ConnectionString}{eventData.ToString()}");
        return base.TransactionStarted(connection, eventData, result);
    }

    public override ValueTask<InterceptionResult<DbTransaction>> TransactionStartingAsync(DbConnection connection, TransactionStartingEventData eventData, InterceptionResult<DbTransaction> result, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionStartingAsync", $"{connection.ConnectionString}{eventData.ToString()}");
        return base.TransactionStartingAsync(connection, eventData, result, cancellationToken);
    }

    public override ValueTask<DbTransaction> TransactionStartedAsync(DbConnection connection, TransactionEndEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionStartedAsync", $"{connection.ConnectionString}{eventData.ToString()}");
        return base.TransactionStartedAsync(connection, eventData, result, cancellationToken);
    }

    public override DbTransaction TransactionUsed(DbConnection connection, TransactionEventData eventData, DbTransaction result)
    {
        LogInfo("TransactionStartingAsync", $"{connection.ConnectionString}{eventData.ToString()}");

        return base.TransactionUsed(connection, eventData, result);
    }

    public override ValueTask<DbTransaction> TransactionUsedAsync(DbConnection connection, TransactionEventData eventData, DbTransaction result, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionUsedAsync", $"{connection.ConnectionString}{eventData.ToString()}");

        return base.TransactionUsedAsync(connection, eventData, result, cancellationToken);
    }
    
    public override InterceptionResult TransactionCommitting(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        LogInfo("TransactionCommitting", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.TransactionCommitting(transaction, eventData, result);
    }

    public override void TransactionCommitted(DbTransaction transaction, TransactionEndEventData eventData)
    {
        LogInfo("TransactionCommitted", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        base.TransactionCommitted(transaction, eventData);
    }

    public override ValueTask<InterceptionResult> TransactionCommittingAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionCommittingAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.TransactionCommittingAsync(transaction, eventData, result, cancellationToken);
    }

    public override Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionCommittedAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");
        return base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
    }

    public override InterceptionResult TransactionRollingBack(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        LogInfo("TransactionRollingBack", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");
        return base.TransactionRollingBack(transaction, eventData, result);
    }

    public override void TransactionRolledBack(DbTransaction transaction, TransactionEndEventData eventData)
    {
        LogInfo("TransactionRolledBack", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        base.TransactionRolledBack(transaction, eventData);
    }

    public override ValueTask<InterceptionResult> TransactionRollingBackAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionRollingBackAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.TransactionRollingBackAsync(transaction, eventData, result, cancellationToken);
    }

    public override Task TransactionRolledBackAsync(DbTransaction transaction, TransactionEndEventData eventData, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionRolledBackAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.TransactionRolledBackAsync(transaction, eventData, cancellationToken);
    }

    public override InterceptionResult CreatingSavepoint(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        LogInfo("CreatingSavepoint", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.CreatingSavepoint(transaction, eventData, result);
    }

    public override void CreatedSavepoint(DbTransaction transaction, TransactionEventData eventData)
    {
        LogInfo("CreatedSavepoint", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        base.CreatedSavepoint(transaction, eventData);
    }

    public override ValueTask<InterceptionResult> CreatingSavepointAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        LogInfo("CreatingSavepointAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.CreatingSavepointAsync(transaction, eventData, result, cancellationToken);
    }

    public override Task CreatedSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
    {
        LogInfo("CreatedSavepointAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.CreatedSavepointAsync(transaction, eventData, cancellationToken);
    }

    public override InterceptionResult RollingBackToSavepoint(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        LogInfo("RollingBackToSavepoint", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.RollingBackToSavepoint(transaction, eventData, result);
    }

    public override void RolledBackToSavepoint(DbTransaction transaction, TransactionEventData eventData)
    {
        LogInfo("RolledBackToSavepoint", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        base.RolledBackToSavepoint(transaction, eventData);
    }

    public override ValueTask<InterceptionResult> RollingBackToSavepointAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        LogInfo("RollingBackToSavepointAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.RollingBackToSavepointAsync(transaction, eventData, result, cancellationToken);
    }

    public override Task RolledBackToSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
    {
        LogInfo("RolledBackToSavepointAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.RolledBackToSavepointAsync(transaction, eventData, cancellationToken);
    }

    public override InterceptionResult ReleasingSavepoint(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result)
    {
        LogInfo("ReleasingSavepoint", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.ReleasingSavepoint(transaction, eventData, result);
    }

    public override void ReleasedSavepoint(DbTransaction transaction, TransactionEventData eventData)
    {
        LogInfo("ReleasedSavepoint", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        base.ReleasedSavepoint(transaction, eventData);
    }

    public override ValueTask<InterceptionResult> ReleasingSavepointAsync(DbTransaction transaction, TransactionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
    {
        LogInfo("ReleasingSavepointAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.ReleasingSavepointAsync(transaction, eventData, result, cancellationToken);
    }

    public override Task ReleasedSavepointAsync(DbTransaction transaction, TransactionEventData eventData, CancellationToken cancellationToken = default)
    {
        LogInfo("ReleasedSavepointAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.ReleasedSavepointAsync(transaction, eventData, cancellationToken);
    }

    public override void TransactionFailed(DbTransaction transaction, TransactionErrorEventData eventData)
    {
        LogInfo("TransactionFailed", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        base.TransactionFailed(transaction, eventData);
    }

    public override Task TransactionFailedAsync(DbTransaction transaction, TransactionErrorEventData eventData, CancellationToken cancellationToken = default)
    {
        LogInfo("TransactionFailedAsync", $"{transaction.Connection?.ConnectionString}{eventData.ToString()}");

        return base.TransactionFailedAsync(transaction, eventData, cancellationToken);
    }

    private void LogInfo(string method, string data)
    {
        _logger.LogInformation("Intercepted on: {0}: \n\t{1}", method, data);
    }
}
