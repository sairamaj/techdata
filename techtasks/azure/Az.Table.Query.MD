```csharp

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

class AzureTable {
    private readonly string storageAccount;
    private readonly string storageKey;

    public AzureTable (string storageAccount, string storageKey) {
        this.storageAccount = storageAccount;
        this.storageKey = storageKey;
    }
    public CloudTable Get (string name) {
        var acc = new CloudStorageAccount (
            new StorageCredentials (this.storageAccount, this.storageKey), true);
        var tableClient = acc.CreateCloudTableClient ();
        return tableClient.GetTableReference (name);
    }

    public async Task<IEnumerable<T>> Query<T> (string tableName, DateTime sinceDateTime) where T : ITableEntity, new () {
        TableContinuationToken token = null;
        var table = this.Get (tableName);
        var entities = new List<T> ();
        do {
            var queryResult = await table.ExecuteQuerySegmentedAsync (new TableQuery<T> ()
                .Where (TableQuery.GenerateFilterCondition ("PartitionKey", QueryComparisons.GreaterThanOrEqual, sinceDateTime.Ticks.ToString ()))
                //                .OrderByDesc("Timestamp")
                //.Take(10)
                ,
                token);
            entities.AddRange (queryResult.Results);
            token = queryResult.ContinuationToken;
        } while (token != null);

        return entities;
    }
}
```