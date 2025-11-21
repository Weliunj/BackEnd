using System;
using System.Collections.Generic;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Entity;

public partial class MinecraftContext : DbContext
{
    public MinecraftContext()
    {
    }

    public MinecraftContext(DbContextOptions<MinecraftContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Craft> Crafts { get; set; }

    public virtual DbSet<DoQuest> DoQuests { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Mode> Modes { get; set; }

    public virtual DbSet<Play> Plays { get; set; }

    public virtual DbSet<PlayResource> PlayResources { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeDetail> RecipeDetails { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__Account__DD771E3C9DED8FB7");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E61643AF4D126").IsUnique();

            entity.HasIndex(e => e.CharName, "UQ__Account__ABC56DFBC72FA5B8").IsUnique();

            entity.Property(e => e.UId).HasColumnName("uID");
            entity.Property(e => e.CharName)
                .HasMaxLength(50)
                .HasColumnName("charName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Craft>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Craft__D830D45714F634FC");

            entity.ToTable("Craft");

            entity.Property(e => e.CId).HasColumnName("cID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.RcId).HasColumnName("rcID");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Crafts)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Craft__pID__1EA48E88");

            entity.HasOne(d => d.Rc).WithMany(p => p.Crafts)
                .HasForeignKey(d => d.RcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Craft__rcID__1F98B2C1");
        });

        modelBuilder.Entity<DoQuest>(entity =>
        {
            entity.HasKey(e => e.DqId).HasName("PK__DoQuest__2D1CC078901890FC");

            entity.ToTable("DoQuest");

            entity.Property(e => e.DqId).HasColumnName("dqID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.QId).HasColumnName("qID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.DoQuests)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoQuest__pID__1BC821DD");

            entity.HasOne(d => d.QIdNavigation).WithMany(p => p.DoQuests)
                .HasForeignKey(d => d.QId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoQuest__qID__1AD3FDA4");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InId).HasName("PK__Inventor__94BA3A3680318FAC");

            entity.ToTable("Inventory");

            entity.Property(e => e.InId).HasColumnName("inID");
            entity.Property(e => e.IId).HasColumnName("iID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(0)
                .HasColumnName("quantity");

            entity.HasOne(d => d.IIdNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.IId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__iID__03F0984C");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__pID__02FC7413");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IId).HasName("PK__Item__DC512D728993379F");

            entity.ToTable("Item");

            entity.HasIndex(e => e.IName, "UQ__Item__163DA42576B06281").IsUnique();

            entity.Property(e => e.IId).HasColumnName("iID");
            entity.Property(e => e.IImg)
                .HasMaxLength(255)
                .HasColumnName("iImg");
            entity.Property(e => e.IKind)
                .HasDefaultValue(0)
                .HasColumnName("iKind");
            entity.Property(e => e.IName)
                .HasMaxLength(50)
                .HasColumnName("iName");
            entity.Property(e => e.IPrice)
                .HasDefaultValue(0)
                .HasColumnName("iPrice");
        });

        modelBuilder.Entity<Mode>(entity =>
        {
            entity.HasKey(e => e.MId).HasName("PK__Mode__DF513EB4D84AC301");

            entity.ToTable("Mode");

            entity.Property(e => e.MId).HasColumnName("mID");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .HasColumnName("mName");
        });

        modelBuilder.Entity<Play>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Play__DD36D5020C18C497");

            entity.ToTable("Play");

            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.Exp)
                .HasDefaultValue(0)
                .HasColumnName("exp");
            entity.Property(e => e.Health).HasColumnName("health");
            entity.Property(e => e.Hunger).HasColumnName("hunger");
            entity.Property(e => e.MId).HasColumnName("mID");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.UId).HasColumnName("uID");
            entity.Property(e => e.WorldName)
                .HasMaxLength(30)
                .HasColumnName("worldName");

            entity.HasOne(d => d.MIdNavigation).WithMany(p => p.Plays)
                .HasForeignKey(d => d.MId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Play__mID__7A672E12");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Plays)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Play__uID__797309D9");
        });

        modelBuilder.Entity<PlayResource>(entity =>
        {
            entity.HasKey(e => e.PrId).HasName("PK__PlayReso__466486B5B0F7124E");

            entity.ToTable("PlayResource");

            entity.Property(e => e.PrId).HasColumnName("prID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(0)
                .HasColumnName("quantity");
            entity.Property(e => e.RId).HasColumnName("rID");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.PlayResources)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayResourc__pID__09A971A2");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.PlayResources)
                .HasForeignKey(d => d.RId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayResourc__rID__0A9D95DB");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QId).HasName("PK__Quest__C276CFE92689786B");

            entity.ToTable("Quest");

            entity.HasIndex(e => e.QName, "UQ__Quest__05FC0926394CCCB4").IsUnique();

            entity.Property(e => e.QId).HasColumnName("qID");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.IId).HasColumnName("iID");
            entity.Property(e => e.MId).HasColumnName("mID");
            entity.Property(e => e.QName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("qName");

            entity.HasOne(d => d.IIdNavigation).WithMany(p => p.Quests)
                .HasForeignKey(d => d.IId)
                .HasConstraintName("FK__Quest__iID__17036CC0");

            entity.HasOne(d => d.MIdNavigation).WithMany(p => p.Quests)
                .HasForeignKey(d => d.MId)
                .HasConstraintName("FK__Quest__mID__17F790F9");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RcId).HasName("PK__Recipe__CA284E31E5B61E62");

            entity.ToTable("Recipe");

            entity.Property(e => e.RcId).HasColumnName("rcID");
            entity.Property(e => e.IId).HasColumnName("iID");
            entity.Property(e => e.RcName)
                .HasMaxLength(100)
                .HasColumnName("rcName");

            entity.HasOne(d => d.IIdNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.IId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipe__iID__0E6E26BF");
        });

        modelBuilder.Entity<RecipeDetail>(entity =>
        {
            entity.HasKey(e => e.RcldId).HasName("PK__RecipeDe__94BB89FE813DC0C1");

            entity.ToTable("RecipeDetail");

            entity.Property(e => e.RcldId).HasColumnName("rcldID");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasColumnName("quantity");
            entity.Property(e => e.RId).HasColumnName("rID");
            entity.Property(e => e.RcId).HasColumnName("rcID");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.RecipeDetails)
                .HasForeignKey(d => d.RId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeDetai__rID__114A936A");

            entity.HasOne(d => d.Rc).WithMany(p => p.RecipeDetails)
                .HasForeignKey(d => d.RcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeDeta__rcID__123EB7A3");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK__Resource__C2BEC9101C33FCC9");

            entity.ToTable("Resource");

            entity.Property(e => e.RId).HasColumnName("rID");
            entity.Property(e => e.RImg)
                .HasMaxLength(255)
                .HasColumnName("rImg");
            entity.Property(e => e.RName)
                .HasMaxLength(30)
                .HasColumnName("rName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
