using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Aghsat.Domain.Entity;

namespace Aghsat.DataLayer.EntityConfig
{
    public class VehicleConfig : EntityTypeConfiguration<Vehicle>
    {

        public VehicleConfig()
        {
            Property(x => x.Name).HasMaxLength(25).IsUnicode().IsRequired().IsMaxLength();
            Property(x => x.Vin).HasMaxLength(15).IsUnicode().IsRequired().IsMaxLength();
            Property(x => x.MotorNo).IsOptional().IsOptional();
        }
    }
}
