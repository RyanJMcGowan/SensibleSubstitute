using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SensibleComponents.Authors;
using SensibleComponents.Categories;
using SensibleComponents.Posts;
using SensibleComponents.Schedules;
using SensibleComponents.Tags;
using System.Configuration;
using SensibleComponents.Comments;
using SensibleComponents;
using SensibleComponents.Contacts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensibleService.Data
{
    public class PostContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlackListWord> BlackListedWords { get; set; }

        public PostContext()
            : base(ConfigurationManager.ConnectionStrings["SeSDev"].ConnectionString)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressComponentMap());
            modelBuilder.Configurations.Add(new AuthorComponentMap());
            modelBuilder.Configurations.Add(new BlackListWordComponentMap());
            modelBuilder.Configurations.Add(new CategoryComponentMap());
            modelBuilder.Configurations.Add(new CommentsComponentMap());
            modelBuilder.Configurations.Add(new ContactInfoComponentMap());
            modelBuilder.Configurations.Add(new EmailComponentMap());
            modelBuilder.Configurations.Add(new PostComponentMap());
            modelBuilder.Configurations.Add(new ScheduleComponentMap());
            modelBuilder.Configurations.Add(new TagComponentMap());
        }
    }

    public class AddressComponentMap : EntityTypeConfiguration<Address>
    {
        public AddressComponentMap()
        {
            this.Map(a => a.MapInheritedProperties()).ToTable("Addresses");
            this.Property(a => a.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class AuthorComponentMap : EntityTypeConfiguration<Author>
    {
        public AuthorComponentMap()
        {
            this.Map(a => a.MapInheritedProperties()).ToTable("Authors");
            this.Property(a => a.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasOptional(a => a.ContacntInfo);
        }
    }

    public class BlackListWordComponentMap : EntityTypeConfiguration<BlackListWord>
    {
        public BlackListWordComponentMap()
        {
            this.Map(b => b.MapInheritedProperties()).ToTable("BlackListWords");
            this.Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class CategoryComponentMap : EntityTypeConfiguration<Category>
    {
        public CategoryComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("Categories");
            this.Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class CommentsComponentMap : EntityTypeConfiguration<Comment>
    {
        public CommentsComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("Comments");
            this.Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.Post).WithMany();
        }
    }

    public class ContactInfoComponentMap : EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfoComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("ContactInfo");
            this.Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Ignore(c => c.PrimaryEmail);
            this.Ignore(c => c.PrimaryAddress);
            this.HasMany(c => c.Addresses);
            this.HasMany(c => c.Emails);
        }
    }

    public class EmailComponentMap : EntityTypeConfiguration<Email>
    {
        public EmailComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("Emails");
            this.Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(e => e.Contact);
        }
    }

    public class PostComponentMap : EntityTypeConfiguration<Post>
    {
        public PostComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("Posts");
            this.Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasMany(p => p.Categories);
            this.HasMany(p => p.Tags);
            this.HasMany(p => p.UpVotes);
            this.HasRequired(p => p.Author);
            this.HasRequired(p => p.Schedule);
        }
    }

    public class ScheduleComponentMap : EntityTypeConfiguration<Schedule>
    {
        public ScheduleComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("Schedules");
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class TagComponentMap : EntityTypeConfiguration<Tag>
    {
        public TagComponentMap()
        {
            this.Map(m => m.MapInheritedProperties()).ToTable("Tags");
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
        }
    }
}