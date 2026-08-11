namespace KamiSama.Modules.Identity.Services.Roles;

public interface IListRoles : IListFeature<RoleDto, RoleSearchModel>;
public interface IAddRole : IAddFeature<AddRoleRequest, RoleDto>;
public interface IUpdateRole : IUpdateFeature<UpdateRoleRequest, Guid>;
public interface IDeleteRole : IDeleteFeature<Guid>;
public interface IFindRoleById : IFindByIdFeature<RoleDto, Guid>;
public interface IFindRoleByName : IFindByNameFeature<RoleDto>;
public interface IExistsRoleById : IExistsByIdFeature<Guid>;
public interface IExistsRoleByName : IExistsByNameFeature;
