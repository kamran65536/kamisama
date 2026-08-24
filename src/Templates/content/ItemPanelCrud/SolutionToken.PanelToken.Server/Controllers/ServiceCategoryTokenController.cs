using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionToken.PanelToken.Services.ServiceCategoryToken;

namespace SolutionToken.PanelToken.Controllers;

[ApiController]
[Authorize]
[Route("api/ServiceCategoryToken")]
public sealed class ServiceCategoryTokenController(
    IAddItemName add,
    IUpdateItemName update,
    IDeleteItemName delete,
    IFindItemNameById findById,
    IListItemNames list) : ControllerBase
{
    [HttpPost]
    public Task<ItemNameDto> Add(AddItemNameRequest request, CancellationToken cancellationToken)
        => add.AddAsync(request, cancellationToken);

#if (KeyType == "Guid")
    [HttpPut("{id:guid}")]
#elseif (KeyType == "int")
    [HttpPut("{id:int}")]
#elseif (KeyType == "long")
    [HttpPut("{id:long}")]
#else
    [HttpPut("{id}")]
#endif
    public Task Update(KeyTypeToken id, UpdateItemNameRequest request, CancellationToken cancellationToken)
        => update.UpdateAsync(id, request, cancellationToken);

#if (KeyType == "Guid")
    [HttpDelete("{id:guid}")]
#elseif (KeyType == "int")
    [HttpDelete("{id:int}")]
#elseif (KeyType == "long")
    [HttpDelete("{id:long}")]
#else
    [HttpDelete("{id}")]
#endif
    public Task Delete(KeyTypeToken id, CancellationToken cancellationToken)
        => delete.DeleteAsync(id, cancellationToken);

#if (KeyType == "Guid")
    [HttpGet("{id:guid}")]
#elseif (KeyType == "int")
    [HttpGet("{id:int}")]
#elseif (KeyType == "long")
    [HttpGet("{id:long}")]
#else
    [HttpGet("{id}")]
#endif
    public Task<ItemNameDto> FindById(KeyTypeToken id, CancellationToken cancellationToken)
        => findById.FindByIdAsync(id, cancellationToken);

    [HttpGet]
    public Task<KamiSama.Extensions.Paging.PagedResult<ItemNameListItemDto>> List(
        [FromQuery] ItemNameSearchModel searchModel,
        CancellationToken cancellationToken)
        => list.ListAsync(searchModel, cancellationToken);
}
