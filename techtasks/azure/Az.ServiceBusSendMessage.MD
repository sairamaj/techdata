```csharp
            var connectionString = "connectonstring";
            var queueName = "queue_name";
            IQueueClient client = new QueueClient (connectionString, queueName);

            var task = client.SendAsync (new Message (System.Text.Encoding.UTF8.GetBytes (JsonConvert.SerializeObject(message))));

```