using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCoreEntityFormworkModel
{
    public class UserMap : DbEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Password).IsRequired().HasMaxLength(100);
            entity.Property(c => c.UserName).IsRequired().HasMaxLength(100);
        }
    }
}
