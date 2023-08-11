using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Data.Configuration
{
    public class TravelTaskConfiguration : IEntityTypeConfiguration<TravelTask>
    {
        void IEntityTypeConfiguration<TravelTask>.Configure(EntityTypeBuilder<TravelTask> builder)
        {
            builder.Property(et => et.Transportation)
               .HasColumnType("varchar(30)");
            builder.Property(et => et.Destination)
                .HasColumnType("varchar(55)");
            builder.ToTable("TravelTasks"); 
        }
    }
}
