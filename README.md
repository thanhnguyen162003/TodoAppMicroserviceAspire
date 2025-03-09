# Todo App: Practical .NET Aspire. This app is for testing new implementation

## Introduction

<p align="justify">
⭐ This is a note project to demonstrate the practical use of .NET Aspire. The project is a cloud-native application with applying Domain-Driven Design (DDD) and Clean Architecture to organize the codebase.
</p>

## The Goals of the Project

- [x] Building a cloud-native application with .NET Aspire
- [x] Using `Clean Architecture` to organize the codebase
- [x] Using `Domain-Driven Design` to design the domain model
- [x] Implement the `CQRS` pattern with `MediatR`
- [ ] Using `RabbitMQ` on top `MassTransit` for messaging
- [x] Using `gRPC` for inter-service communication
- [x] API versioning
- [x] Health checks
- [x] OpenAPI/Swagger-Scalar
- [x] AuthN/AuthZ with `Duende IdentityServer`
- [x] Observability/Resilience with `.NET Aspire`
- [x] CI/CD with `GitHub Actions`
- [ ] Output Caching, Response Caching and Distributed Caching with Redis
- [ ] Hybrid Cache using in .net 9
- [ ] Distributed Tracing
- [ ] Dapr for distributed system
- [ ] Dapper for SQL raw query
- [ ] 
- [ ] Deployment with `K8s` and `docker`
- [ ] Thinking...

## Domain Business & Bounded Contexts - Services Boundaries

- **ToDoService**: Handling crud, search for to do functionality.
- **OpenAIService**: Handling AI functionality.
- **SyncService**: Handling Synchronus.
- **Payment**: Payment functionality.
- **Identity**: Register, login, and manage user profile.
- **Notification**: Send email notifications.
