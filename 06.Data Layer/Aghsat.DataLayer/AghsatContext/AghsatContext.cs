using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Aghsat.Domain;
using Aghsat.Domain.Entity;
using System.Data.Entity.Validation;
using Aghsat.DataLayer.EntityConfig;

namespace Aghsat.DataLayer.AghsatContext
{
    public class AghsatContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>, IUnitOfWork
    {

        #region  Constructor

        public AghsatContext() : base("Aghsat")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Entites
        public DbSet<Vehicle> vehicle { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Unit> Units { get; set; }





        #endregion

        #region on model Creating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");

            modelBuilder.Configurations.Add(new VehicleConfig());


        }

        #endregion

        #region Unit of Work
        public int SaveAllChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException excption)
            {
                foreach (var e in excption.EntityValidationErrors)
                {
                    foreach (var item in e.ValidationErrors)
                    {
                        Console.WriteLine("Property {0} , Error {1}", item.PropertyName, item.ErrorMessage);
                    }
                }
                throw;
            }

        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public override DbSet Set(Type entityType)
        {
            return base.Set(entityType);
        }
        public void MarkAsChanges<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Entry(entity).State = EntityState.Modified;
        }
        public void MarkAsDelete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Entry(entity).State = EntityState.Deleted;
        }

        #endregion


    }

}
