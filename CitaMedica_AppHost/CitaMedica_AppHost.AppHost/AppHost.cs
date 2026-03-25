var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CitaMedica_AppHost_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.CitaMedica_AppHost_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
