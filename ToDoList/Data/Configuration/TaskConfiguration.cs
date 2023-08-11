using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Data.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Tasks>
    {
        void IEntityTypeConfiguration<Tasks>.Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.
                UseTptMappingStrategy().ToTable("Tasks");
            builder.HasKey(x => x.Id);
   
            builder.Property(t => t.Title).HasColumnType("varchar(55)");
            builder.Property(t => t.Description).HasColumnType("varchar(max)");

        }
    }
}
