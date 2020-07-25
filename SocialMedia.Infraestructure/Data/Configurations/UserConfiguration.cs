using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infraestructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Usuario");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("IdUsuario");

            entity.Property(e => e.FirstName)
              .HasColumnName("Nombres")
              .IsRequired()
              .HasMaxLength(50)
              .IsUnicode(false);


            entity.Property(e => e.LastName)
                .HasColumnName("Apellidos")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.DateBirthday)
                 .HasColumnName("FechaNacimiento")
                 .HasColumnType("date");

            entity.Property(e => e.Telephone)
                .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.IsActive)
              .HasColumnName("Activo");

        }
    }
}
