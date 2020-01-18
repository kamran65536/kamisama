using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace KamiSama.Extenders.EntityFramework
{
	public class CustomHistoryContext<_ContextType> : HistoryContext
		where _ContextType : DbContext
	{
		private Action<DbModelBuilder> modelBuildingCreatingAction;

		public CustomHistoryContext(DbConnection existingConnection, string defaultSchema, Action<DbModelBuilder> modelBuildingCreatingAction) : base(existingConnection, defaultSchema)
		{
			this.modelBuildingCreatingAction = modelBuildingCreatingAction;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuildingCreatingAction(modelBuilder);
		}
	}
}
