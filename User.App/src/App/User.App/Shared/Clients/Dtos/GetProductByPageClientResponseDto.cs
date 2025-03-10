using Shared.Core.Paging;

namespace User.App.Shared.Clients.Dtos;

public record GetProductByPageClientResponseDto(PageList<ProductClientDto> Products);