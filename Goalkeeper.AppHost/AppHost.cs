var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var goalkeeperDb = postgres.AddDatabase("goal-keeper-db");

var server = builder.AddProject<Projects.Goalkeeper_Server>("server")
    .WaitFor(goalkeeperDb)
    .WithReference(goalkeeperDb)
    .WithHttpHealthCheck("/health")
    .WithUrl("/swagger", "Swagger UI");

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
