using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniqueWords.Database.Models
{
    public class WatchList
    {
        public int Id { get; set; }
        public string WatchedWord { get; set; }
    }
    public class WatchListConfiguration : IEntityTypeConfiguration<WatchList>
    {
        public void Configure(EntityTypeBuilder<WatchList> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.Property(x => x.WatchedWord)
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}
