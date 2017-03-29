using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(x => x.Id);
            Property(x => x.Password).IsRequired().HasMaxLength(1024);
            Property(x=>x.Username).IsRequired().HasMaxLength(1024);
        }
    }
}
