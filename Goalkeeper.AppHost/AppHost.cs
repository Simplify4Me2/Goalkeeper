var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("sqldb");

var server = builder.AddProject<Projects.Goalkeeper_Server>("server")
    .WaitFor(sqldb)
    .WithReference(sqldb)
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();
    //.WithHttpEndpoint(() =>
    //{
        
    //});

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
