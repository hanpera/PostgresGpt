var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.PostgresGpt_ApiService>("apiservice");

builder.AddProject<Projects.PostgresGpt_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
