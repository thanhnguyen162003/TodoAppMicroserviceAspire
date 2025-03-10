namespace User.App.Shared.Clients.Dtos;

public record CreateProductClientRequestDto(string Name, Guid CategoryId, decimal Price, string? Description);