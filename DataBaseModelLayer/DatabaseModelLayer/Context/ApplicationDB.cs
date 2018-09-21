using Microsoft.EntityFrameworkCore;
using AccountCore.DataModels;
using CRM.DatabaseModelLayer.Models;

namespace CRM.DatabaseModelLayer.Context
{
	public class ApplicationDB : DbContext
	{

		public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
		{


		}
		public virtual DbSet<Project_Master> ProjectMasters { get; set; }
		public virtual DbSet<Application_Modules> ApplicationModules { get; set; }
		public virtual DbSet<Asset_Master> AssetMasters { get; set; }
		public virtual DbSet<Building_Plan_Master> BuildingPlanMasters { get; set; }
		public virtual DbSet<Mouels_Roles_Link> MouelsRolesLink { get; set; }
		

		public virtual DbSet<ApplicationUsers> ApplicationUsers { get; set; }
		public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }
		public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Project_Master>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(p =>p.GoalSellingAmount).HasColumnType("decimal(12, 0)");
				entity.Property(p => p.TotalProjectArea).HasColumnType("decimal(12, 0)");
				entity.ToTable("Project_Master");
			});

			modelBuilder.Entity<ApplicationUserRole>(entity =>
			{
				entity.HasKey(e => e.ApplicationUserRoleId);
				entity.Property(p => p.ApplicationUserRoleId).ValueGeneratedNever();
			});

			modelBuilder.Entity<ApplicationUserRole>(entity =>
			{
				entity.HasKey(e => e.ApplicationUserRoleId);
				entity.Property(p => p.ApplicationUserRoleId).ValueGeneratedNever();
			});


			


			base.OnModelCreating(modelBuilder);
		}
	}
}
