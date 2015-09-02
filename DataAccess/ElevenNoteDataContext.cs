

using ElevenNote.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.DataAccess
{
    public class ElevenNoteDataContext : IdentityDbContext<ElevenNoteApplicationUser>, IDisposable
    {
        #region Constructor

        public ElevenNoteDataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public ElevenNoteDataContext(string connectionString = "DefaultConnection")
            : base("DefaultConnection")
        {
            // Nothing else to do here; it's all handled by the base class.
        }

        #endregion

        /// <summary>
        /// Factory method to return a new instance.
        /// </summary>
        /// <returns></returns>
        public static ElevenNoteDataContext Create()
        {
            return new ElevenNoteDataContext();
        }

        #region Datasets

        // Below are the extra tables, aside from what's automatically created by the identity framework.

        public DbSet<Note> Notes { get; set; }

        #endregion

        #region Stuff to add because we're merging Identity Framework data creation with our own context

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration()); // solves foreign key issues combining databases
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
        }

        #endregion

    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {

        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }

    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {

        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.RoleId);
        }

    }
}

