namespace ExampleNamespace;

public static class DtoMappings
{
	//#if (IncludeEntities)
	public static SampleEntityDto ToDto(this SampleEntity entity)
		=> new(entity.Id, entity.Name);
	//#endif
}

//#if (IncludeEntities)
public record SampleEntityDto(Guid Id, string Name);
//#endif
