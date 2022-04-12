using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace UniqueWords.Database.Models
{
    public class UniqueWordList
    {
        public int Id { get; set; }
        public string UniqueWordName { get; set; }
    }
    public class UniqueWordListConfiguration : IEntityTypeConfiguration<UniqueWordList>
    {
        public void Configure(EntityTypeBuilder<UniqueWordList> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.Property(x => x.UniqueWordName)
                .HasMaxLength(250)
                .IsRequired();

        }
    }
}
