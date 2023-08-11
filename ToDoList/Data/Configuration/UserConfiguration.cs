using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(U => U.Id).
                ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(U => U.First_Name).
                     HasColumnType("varchar(30)");
            builder.Property(U => U.Last_Name).
                     HasColumnType("varchar(30)");
            builder.Property(U => U.Email)
                .HasColumnType("varchar(55)");
            builder.Property(U => U.Password)
             .HasColumnType("varchar(16)");
            builder.Property(U => U.Phone)
             .HasColumnType("varchar(11)");
            builder.HasIndex
                (x => x.Phone).IsUnique();
            builder.HasIndex
              (x => x.Email).IsUnique();

            builder.HasMany(u=>u.tasks)
                .WithOne(t=>t.User).
                HasForeignKey(t => t.UserId).IsRequired(true)
                .HasPrincipalKey(u=>u.Id);   
        }
    }
}
