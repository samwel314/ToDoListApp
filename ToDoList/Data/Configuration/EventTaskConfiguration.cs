using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.Data.Configuration
{
    public class EventTaskConfiguration : IEntityTypeConfiguration<EventTask>
    {
        void IEntityTypeConfiguration<EventTask>.Configure(EntityTypeBuilder<EventTask> builder)
        {
            builder.Property(et => et.Event_Name)
                .HasColumnType("varchar(55)");
            builder.Property(et => et.Location)
                .HasColumnType("varchar(55)");
            builder.Property(et => et.Assigment)
                .HasColumnType("varchar(55)");
            builder.ToTable("EventTasks");
        }
    }
}
