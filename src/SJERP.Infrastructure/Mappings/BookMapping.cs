﻿
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
    //public class BookMapping : IEntityTypeConfiguration<Book>
    //{
    //    public void Configure(EntityTypeBuilder<Book> builder)
    //    {
    //        builder.HasKey(b => b.Id);

    //        builder.Property(b => b.Name)
    //            .IsRequired()
    //            .HasColumnType("varchar(150)");

    //        builder.Property(b => b.Author)
    //             .IsRequired()
    //             .HasColumnType("varchar(150)");

    //        builder.Property(b => b.Description)
    //            .IsRequired(false)
    //            .HasColumnType("varchar(350)");

    //        builder.Property(b => b.Value)
    //            .IsRequired();

    //        builder.Property(b => b.PublishedDate)
    //            .IsRequired();

    //        builder.Property(b => b.CategoryId)
    //            .IsRequired();

    //        builder.ToTable("Books");

    //    }
    //}

}
