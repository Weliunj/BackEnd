using System;
using System.Collections.Generic;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Entity;

public partial class Gam106Context : DbContext
{
    public Gam106Context()
    {
    }

    public Gam106Context(DbContextOptions<Gam106Context> options)
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

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Recipedetail> Recipedetails { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Transation> Transations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__Account__DD701264D16DED0C");

            entity.ToTable("Account");

            entity.HasIndex(e => e.Email, "UQ__Account__AB6E61649F917766").IsUnique();

            entity.HasIndex(e => e.CharName, "UQ__Account__ABC56DFB2C67402B").IsUnique();

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.CharName)
                .HasMaxLength(50)
                .HasColumnName("charName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Craft>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Craft__D837D05F6DCA583F");

            entity.ToTable("Craft");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Rid).HasColumnName("rid");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.Crafts)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Craft__pid__10566F31");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.Crafts)
                .HasForeignKey(d => d.Rid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Craft__rid__114A936A");
        });

        modelBuilder.Entity<DoQuest>(entity =>
        {
            entity.HasKey(e => e.Dqid).HasName("PK__DoQuest__2D11D420EACBC9E5");

            entity.ToTable("DoQuest");

            entity.Property(e => e.Dqid).HasColumnName("dqid");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Qid).HasColumnName("qid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.DoQuests)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoQuest__pid__04E4BC85");

            entity.HasOne(d => d.QidNavigation).WithMany(p => p.DoQuests)
                .HasForeignKey(d => d.Qid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoQuest__qid__05D8E0BE");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Ivid).HasName("PK__Inventor__9AB95E83359B772F");

            entity.ToTable("Inventory");

            entity.Property(e => e.Ivid).HasColumnName("ivid");
            entity.Property(e => e.Iid).HasColumnName("iid");
            entity.Property(e => e.Ivquan)
                .HasDefaultValue(0)
                .HasColumnName("ivquan");
            entity.Property(e => e.Pid).HasColumnName("pid");

            entity.HasOne(d => d.IidNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Iid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__iid__76969D2E");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__pid__75A278F5");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Iid).HasName("PK__Item__DC5021AA6D38C68A");

            entity.ToTable("Item");

            entity.HasIndex(e => e.Iname, "UQ__Item__135C835EB6EFDB79").IsUnique();

            entity.Property(e => e.Iid).HasColumnName("iid");
            entity.Property(e => e.Ides)
                .HasMaxLength(50)
                .HasColumnName("ides");
            entity.Property(e => e.Ikind)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ikind");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Iname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("iname");
            entity.Property(e => e.Iprice)
                .HasDefaultValue(0)
                .HasColumnName("iprice");
        });

        modelBuilder.Entity<Mode>(entity =>
        {
            entity.HasKey(e => e.Mid).HasName("PK__Mode__DF5032EC32C29A91");

            entity.ToTable("Mode");

            entity.HasIndex(e => e.MName, "UQ__Mode__0654D66F09228B93").IsUnique();

            entity.Property(e => e.Mid).HasColumnName("mid");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mName");
        });

        modelBuilder.Entity<Play>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__Play__DD37D91A7C158C62");

            entity.ToTable("Play");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Exp)
                .HasDefaultValue(0)
                .HasColumnName("exp");
            entity.Property(e => e.Heath).HasColumnName("heath");
            entity.Property(e => e.Hunger).HasColumnName("hunger");
            entity.Property(e => e.Mid).HasColumnName("mid");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.WorldName)
                .HasMaxLength(30)
                .HasColumnName("worldName");

            entity.HasOne(d => d.MidNavigation).WithMany(p => p.Plays)
                .HasForeignKey(d => d.Mid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Play__mid__71D1E811");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.Plays)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Play__uid__70DDC3D8");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.Qid).HasName("PK__Quest__C277C221F9010349");

            entity.ToTable("Quest");

            entity.HasIndex(e => e.QName, "UQ__Quest__05FC09266F2FD5AE").IsUnique();

            entity.Property(e => e.Qid).HasColumnName("qid");
            entity.Property(e => e.Iid).HasColumnName("iid");
            entity.Property(e => e.Mid).HasColumnName("mid");
            entity.Property(e => e.QExp)
                .HasDefaultValue(0)
                .HasColumnName("qExp");
            entity.Property(e => e.QName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("qName");

            entity.HasOne(d => d.IidNavigation).WithMany(p => p.Quests)
                .HasForeignKey(d => d.Iid)
                .HasConstraintName("FK__Quest__iid__403A8C7D");

            entity.HasOne(d => d.MidNavigation).WithMany(p => p.Quests)
                .HasForeignKey(d => d.Mid)
                .HasConstraintName("FK__Quest__mid__3F466844");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Recid).HasName("PK__Recipe__1B427A0AEF6D9BEF");

            entity.ToTable("Recipe");

            entity.Property(e => e.Recid).HasColumnName("recid");
            entity.Property(e => e.RecDes)
                .HasColumnType("text")
                .HasColumnName("recDes");
            entity.Property(e => e.RecImg)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("recImg");
            entity.Property(e => e.RecName)
                .HasMaxLength(30)
                .HasColumnName("recName");
        });

        modelBuilder.Entity<Recipedetail>(entity =>
        {
            entity.HasKey(e => e.Rdid).HasName("PK__Recipede__C56758204896EEE5");

            entity.Property(e => e.Rdid).HasColumnName("rdid");
            entity.Property(e => e.Rdquan)
                .HasDefaultValue(0)
                .HasColumnName("rdquan");
            entity.Property(e => e.Reid).HasColumnName("reid");
            entity.Property(e => e.Rid).HasColumnName("rid");

            entity.HasOne(d => d.Re).WithMany(p => p.Recipedetails)
                .HasForeignKey(d => d.Reid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipedeta__reid__68487DD7");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.Recipedetails)
                .HasForeignKey(d => d.Rid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipedetai__rid__6754599E");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PK__Resource__C2B7EDE8CFF9CEC1");

            entity.ToTable("Resource");

            entity.Property(e => e.Rid).HasColumnName("rid");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Rquan)
                .HasDefaultValue(0)
                .HasColumnName("rquan");
            entity.Property(e => e.Rtype)
                .HasColumnType("text")
                .HasColumnName("rtype");
        });

        modelBuilder.Entity<Transation>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__Transati__DC105B0FC925B9C6");

            entity.ToTable("Transation");

            entity.Property(e => e.Tid).HasColumnName("tid");
            entity.Property(e => e.Iid).HasColumnName("iid");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");

            entity.HasOne(d => d.IidNavigation).WithMany(p => p.Transations)
                .HasForeignKey(d => d.Iid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transation__iid__0D7A0286");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.Transations)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transation__pid__0C85DE4D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
