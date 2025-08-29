using API.Shared.Infrastructure.Options;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Quartz;

namespace API.FileStorage.Application.Features.MongoBusData.Jobs
{
    internal class MongoMessageDataCleanerJob : IJob
    {
        private const string MESSAGE_DATA_DB_NAME = "MessageBusData";

        private readonly TimeSpan _expiration = TimeSpan.FromMinutes(5);

        private readonly IMongoDatabase _mongoDatabase;

        public MongoMessageDataCleanerJob(IOptionsMonitor<MongoDbOptions> optionsMonitor)
        {
            var mongoClient = new MongoClient(optionsMonitor.CurrentValue.ConnectionString);
            _mongoDatabase = mongoClient.GetDatabase(MESSAGE_DATA_DB_NAME);
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var files = _mongoDatabase.GetCollection<BsonDocument>("fs.files");
            var chunks = _mongoDatabase.GetCollection<BsonDocument>("fs.chunks");

            var threshold = DateTime.UtcNow - _expiration;

            var oldFiles = await files.Find(Builders<BsonDocument>.Filter.Lt("uploadDate", threshold)).ToListAsync();

            foreach (var file in oldFiles)
            {
                var id = file["_id"];
                await chunks.DeleteManyAsync(Builders<BsonDocument>.Filter.Eq("files_id", id));
                await files.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", id));
            }
        }
    }
}
