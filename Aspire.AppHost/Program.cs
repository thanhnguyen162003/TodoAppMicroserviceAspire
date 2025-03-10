var builder = DistributedApplication.CreateBuilder(args);

// Add Todo.App project
var todoApp = builder.AddProject("TodoApp", "../Todo.App/src/Application/Application.csproj")
    .WithEndpoint(1234);

// Add User.App project
var userApp = builder.AddProject("UserApp", "../User.App/src/ApiClients/User.App.KiotaClients/User.App.KiotaClients.csproj")
    .WithEndpoint(1233);

builder.Build().Run();