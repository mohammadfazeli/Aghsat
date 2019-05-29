using Aghsat.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.DataLayer.EntityConfig
{
    public class MenuConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            this.HasKey(x => x.Id);

            //this.HasMany(x=>x.SubCategories)
            //    .WithOptional(x => x.ParentMenuId)
            //    .HasForeignKey(course => course.UserId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
