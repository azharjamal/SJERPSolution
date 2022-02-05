using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJERP.Domain.Models;

namespace SJERP.Infrastructure.Mappings
{
    //public class BrandMapping : IEntityTypeConfiguration<Brand>
    //{
    //    public void Configure(EntityTypeBuilder<Brand> builder)
    //    {
    //        builder.HasKey(c => c.Id);

    //        builder.Property(c => c.Name)
    //            .IsRequired()
    //            .HasColumnType("varchar(150)");
    //        // 1: N => Brand : Books
    //        builder.HasMany(c => c.Books)
    //            .WithOne(b => b.Brand)
    //            .HasForeignKey(b => b.BrandId);

    //        builder.ToTable("Brands");



    //    }
    //}


}
