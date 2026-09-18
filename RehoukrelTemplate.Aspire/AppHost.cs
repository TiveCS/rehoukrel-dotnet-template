var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin();

var identityDb = postgres.AddDatabase("local-identity");

builder
    .AddProject<Projects.RehoukrelTemplate_Identity_Api>("identity-api")
    .WithReference(identityDb)
    .WaitFor(identityDb);

builder.Build().Run();