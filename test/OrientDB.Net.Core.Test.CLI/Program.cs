using System;
using OrientDB.Net.Core.Abstractions;
using OrientDB.Net.Core.ConnectionProtocols.Binary;
using OrientDB.Net.Core.DemoDB.Vertices;
using OrientDB.Net.Core.Models;
using OrientDB.Net.Core.Serializers.RecordCSVSerializer;
using Serilog;
using Serilog.Extensions.Logging;

namespace OrientDB.Net.Core.Test.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.WriteTo.Console()
				.CreateLogger();


			IOrientServerConnection server = new OrientDBConfiguration()
				.ConnectWith<byte[]>()
				.Connect(new BinaryProtocol("127.0.0.1", "root", "root"))
				.SerializeWith.Serializer(new OrientDBRecordCSVSerializer())
				.LogWith.Logger(new SerilogLoggerProvider().CreateLogger(typeof(Program).Name))
				.CreateFactory()
				.CreateConnection();

			IOrientDatabaseConnection database;

			database = server.DatabaseConnect("demodb", DatabaseType.Graph);

			var archaelogicalSites = database.ExecuteQuery<ArchaeologicalSites>("SELECT FROM archaeologicalsites");

			var entities = database.ExecuteQuery<OrientDBEntity>(
				"MATCH {class: Customers, as: c, where: (OrderedId=1)}.both(){as: n} RETURN $pathelements");
		}
	}
}
