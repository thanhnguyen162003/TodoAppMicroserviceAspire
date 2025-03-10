var builder = DistributedApplication.CreateBuilder(args);

// Add Todo.App project
var todoApp = builder.AddProject("TodoApp", "../Todo.App/Todo.App.csproj")
    .WithEndpoint(1234);

// Add User.App project
var userApp = builder.AddProject("UserApp", "../User.App/User.App.csproj")
    .WithEndpoint(1233);

builder.Build().Run();