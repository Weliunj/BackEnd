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

    public virtual DbSet<Ptransaction> Ptransactions { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeDetail> RecipeDetails { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=_Minecraft;User Id=sa;Password=ThanhQuy!111226;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__Account__DD771E3C029F54D7");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E6164D5408860").IsUnique();

            entity.HasIndex(e => e.CharName, "UQ__Account__ABC56DFBA1E2148F").IsUnique();

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
            entity.HasKey(e => e.CId).HasName("PK__Craft__D830D457A0FF5C85");

            entity.ToTable("Craft");

            entity.Property(e => e.CId).HasColumnName("cID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.RcId).HasColumnName("rcID");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Crafts)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Craft__pID__540C7B00");

            entity.HasOne(d => d.Rc).WithMany(p => p.Crafts)
                .HasForeignKey(d => d.RcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Craft__rcID__55009F39");
        });

        modelBuilder.Entity<DoQuest>(entity =>
        {
            entity.HasKey(e => e.DqId).HasName("PK__DoQuest__2D1CC078F5DEF5D0");

            entity.ToTable("DoQuest");

            entity.Property(e => e.DqId).HasColumnName("dqID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.QId).HasColumnName("qID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.DoQuests)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoQuest__pID__51300E55");

            entity.HasOne(d => d.QIdNavigation).WithMany(p => p.DoQuests)
                .HasForeignKey(d => d.QId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoQuest__qID__503BEA1C");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InId).HasName("PK__Inventor__94BA3A364F5E73B7");

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
                .HasConstraintName("FK__Inventory__iID__395884C4");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__pID__3864608B");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IId).HasName("PK__Item__DC512D724B66BB1B");

            entity.ToTable("Item");

            entity.HasIndex(e => e.IName, "UQ__Item__163DA425D5A1E0D8").IsUnique();

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
            entity.HasKey(e => e.MId).HasName("PK__Mode__DF513EB459BAE5F8");

            entity.ToTable("Mode");

            entity.Property(e => e.MId).HasColumnName("mID");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .HasColumnName("mName");
        });

        modelBuilder.Entity<Play>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Play__DD36D5029AE82946");

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
                .HasConstraintName("FK__Play__mID__2FCF1A8A");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Plays)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Play__uID__2EDAF651");
        });

        modelBuilder.Entity<PlayResource>(entity =>
        {
            entity.HasKey(e => e.PrId).HasName("PK__PlayReso__466486B5D9748A44");

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
                .HasConstraintName("FK__PlayResourc__pID__3F115E1A");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.PlayResources)
                .HasForeignKey(d => d.RId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayResourc__rID__40058253");
        });

        modelBuilder.Entity<Ptransaction>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__PTransac__DC105B0F89A3B386");

            entity.ToTable("PTransaction");

            entity.Property(e => e.Tid).HasColumnName("tid");
            entity.Property(e => e.IId).HasColumnName("iID");
            entity.Property(e => e.PId).HasColumnName("pID");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
            entity.Property(e => e.Value)
                .HasDefaultValue(0.0)
                .HasColumnName("value");

            entity.HasOne(d => d.IIdNavigation).WithMany(p => p.Ptransactions)
                .HasForeignKey(d => d.IId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PTransactio__iID__58D1301D");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Ptransactions)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PTransactio__pID__57DD0BE4");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QId).HasName("PK__Quest__C276CFE9D447390C");

            entity.ToTable("Quest");

            entity.HasIndex(e => e.QName, "UQ__Quest__05FC09269404C346").IsUnique();

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
                .HasConstraintName("FK__Quest__iID__4C6B5938");

            entity.HasOne(d => d.MIdNavigation).WithMany(p => p.Quests)
                .HasForeignKey(d => d.MId)
                .HasConstraintName("FK__Quest__mID__4D5F7D71");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RcId).HasName("PK__Recipe__CA284E315FFC50B3");

            entity.ToTable("Recipe");

            entity.Property(e => e.RcId).HasColumnName("rcID");
            entity.Property(e => e.IId).HasColumnName("iID");
            entity.Property(e => e.RcName)
                .HasMaxLength(100)
                .HasColumnName("rcName");

            entity.HasOne(d => d.IIdNavigation).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.IId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipe__iID__43D61337");
        });

        modelBuilder.Entity<RecipeDetail>(entity =>
        {
            entity.HasKey(e => e.RcldId).HasName("PK__RecipeDe__94BB89FECAD648EC");

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
                .HasConstraintName("FK__RecipeDetai__rID__46B27FE2");

            entity.HasOne(d => d.Rc).WithMany(p => p.RecipeDetails)
                .HasForeignKey(d => d.RcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RecipeDeta__rcID__47A6A41B");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK__Resource__C2BEC9109298872C");

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
