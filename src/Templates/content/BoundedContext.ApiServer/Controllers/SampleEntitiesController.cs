using KamiSama.Extensions.Paging;
using Example.BoundedContext.Features.SampleEntityManagement;
using Microsoft.AspNetCore.Mvc;

namespace Example.ApiServer.Controllers;
[Route("api/sample-entities")]
[ApiController]
public class SampleEntitiesController : ControllerBase
{
	[HttpGet]
	public Task<PagedResult<SampleEntityDto>> ListAsync(
		[FromServices] IListSampleEntities listEntities,
		[FromQuery] SampleEntitySearchModel searchModel,
		CancellationToken cancellationToken)
		=>listEntities.ListAsync(searchModel, cancellationToken);
	[HttpGet("{id}")]
	public Task<SampleEntityDto> FindByIdAsync(
		[FromServices] IFindSampleEntityById findSampleEntityById,
		[FromRoute] Guid id,
		CancellationToken cancellationToken)
		=> findSampleEntityById.FindByIdAsync(id, cancellationToken);
	[HttpGet("by-name/{name}")]
	public Task<SampleEntityDto> FindByNameAsync(
		[FromServices] IFindSampleEntityByName findSampleEntityByName,
		[FromRoute] string name,
		CancellationToken cancellationToken)
		=> findSampleEntityByName.FindByNameAsync(name, cancellationToken)!;
	[HttpPut]
	public Task AddAsync(
		[FromServices] IAddSampleEntity addSampleEntity,
		[FromBody] AddSampleEntityRequest request,
		CancellationToken cancellationToken)
		=> addSampleEntity.AddAsync(request, cancellationToken);
	[HttpDelete]
	public Task DeleteAsync(
		[FromServices] IDeleteSampleEntity deleteSampleEntity,
		[FromQuery] Guid id,
		CancellationToken cancellationToken)
		=> deleteSampleEntity.DeleteAsync(id, cancellationToken);
	[HttpPatch]
	public Task UpdateAsync(
		[FromServices] IUpdateSampleEntity updateSampleEntity,
		[FromQuery] Guid id,
		[FromBody] UpdateSampleEntityRequest request,
		CancellationToken cancellationToken)
		=> updateSampleEntity.UpdateAsync(id, request, cancellationToken);

}
