var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");
var sqldb = sql.AddDatabase("sqldb");

var server = builder.AddProject<Projects.Goalkeeper_Server>("server")
    .WaitFor(sqldb)
    .WithReference(sqldb)
    .WithHttpHealthCheck("/health")
    //.WithExternalHttpEndpoints()
    //.WithHttpsEndpoint()
    .WithUrl("/swagger", "Swagger UI");
    //.WithUrlForEndpoint("/swagger", url => url.DisplayText = "Swagger UI");
//.WithHttpEndpoint(() =>
//{

//});

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
