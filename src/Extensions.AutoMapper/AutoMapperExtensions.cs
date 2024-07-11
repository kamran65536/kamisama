using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.AutoMapper;

/// <summary>
/// Extensions for auto mapper
/// </summary>
[ExcludeFromCodeCoverage]
public static class AutoMapperExtensions
{
	/// <summary>
	/// Maps fields only if the value is changed (using <see cref="object.Equals(object?, object?)"/>
	/// </summary>
	/// <returns></returns>
	public static IMappingExpression<TSource, TDestination> JustPatchMembers<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
	{
		expression
			.ForAllMembers(opt => opt.Condition((source, destination, sMember, dMember) => !object.Equals(sMember, dMember)));
		return expression;
	}
	/// <summary>
	/// Creates a default mapping and adds <see cref="JustPatchMembers{TSource, TDestination}(IMappingExpression{TSource, TDestination})"/> to it
	/// </summary>
	public static IMappingExpression<TSource, TDestination> CreatedPatchedMap<TSource, TDestination>(this Profile profile, MemberList memberList)
		=> profile.CreateMap<TSource, TDestination>(memberList).JustPatchMembers();
	/// <summary>
	/// Creates a default mapping and adds <see cref="JustPatchMembers{TSource, TDestination}(IMappingExpression{TSource, TDestination})"/> to it
	/// </summary>
	public static IMappingExpression<TSource, TDestination> CreatedPatchedMap<TSource, TDestination>(this Profile profile)
		=> profile.CreateMap<TSource, TDestination>().JustPatchMembers();
}
