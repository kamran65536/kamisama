namespace KamiSama.Modules.Identity.Services.Roles;

/// <summary>Lists roles through the standard paged feature contract.</summary>
public interface IListRoles : IListFeature<RoleDto, RoleSearchModel>;
/// <summary>Creates a role and returns its provider-neutral representation.</summary>
public interface IAddRole : IAddFeature<AddRoleRequest, RoleDto>;
/// <summary>Updates the role identified by a <see cref="Guid"/>.</summary>
public interface IUpdateRole : IUpdateFeature<UpdateRoleRequest, Guid>;
/// <summary>Deletes the role identified by a <see cref="Guid"/>.</summary>
public interface IDeleteRole : IDeleteFeature<Guid>;
/// <summary>Finds a role by its <see cref="Guid"/> identifier.</summary>
public interface IFindRoleById : IFindByIdFeature<RoleDto, Guid>;
/// <summary>Finds a role by name.</summary>
public interface IFindRoleByName : IFindByNameFeature<RoleDto>;
/// <summary>Checks whether a role exists for a <see cref="Guid"/> identifier.</summary>
public interface IExistsRoleById : IExistsByIdFeature<Guid>;
/// <summary>Checks whether a role exists for a name.</summary>
public interface IExistsRoleByName : IExistsByNameFeature;
