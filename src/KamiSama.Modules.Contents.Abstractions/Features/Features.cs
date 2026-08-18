using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Modules.Contents.Features;

/// <summary>
/// Lists a page of content files, without their binary payload, using owner and file filters.
/// </summary>
public interface IListContentFiles : IListFeature<ContentFileListItemDto, ContentFileSearchModel>;
/// <summary>
/// Finds a content file by its <see cref="Guid"/> identifier and returns its full DTO, including binary payload.
/// </summary>
public interface IFindContentFileById : IFindByIdFeature<ContentFileDto, Guid>;
/// <summary>
/// Deletes an existing content file identified by <see cref="Guid"/>.
/// </summary>
public interface IDeleteContentFile : IDeleteFeature<Guid>;
/// <summary>
/// Adds a new content file from an <see cref="AddContentFileRequest"/> and returns the created file's DTO.
/// </summary>
public interface IAddContentFile : IAddFeature<AddContentFileRequest, ContentFileDto>;
