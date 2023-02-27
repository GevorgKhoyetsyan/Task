using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DALL.Models;

namespace Task.DALL.Data.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(512)
                .IsRequired(true);

            builder.Property(p => p.Price)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
 

