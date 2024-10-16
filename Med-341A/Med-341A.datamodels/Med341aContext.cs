using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Med_341A.datamodels;

public partial class Med341aContext : DbContext
{
    public Med341aContext()
    {
    }

    public Med341aContext(DbContextOptions<Med341aContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MAdmin> MAdmins { get; set; }

    public virtual DbSet<MBank> MBanks { get; set; }

    public virtual DbSet<MBiodataAddress> MBiodataAddresses { get; set; }

    public virtual DbSet<MBiodatum> MBiodata { get; set; }

    public virtual DbSet<MBloodGroup> MBloodGroups { get; set; }

    public virtual DbSet<MCourier> MCouriers { get; set; }

    public virtual DbSet<MCourierType> MCourierTypes { get; set; }

    public virtual DbSet<MCustomer> MCustomers { get; set; }

    public virtual DbSet<MCustomerMember> MCustomerMembers { get; set; }

    public virtual DbSet<MCustomerRelation> MCustomerRelations { get; set; }

    public virtual DbSet<MDoctor> MDoctors { get; set; }

    public virtual DbSet<TCourierDiscount> TCourierDiscounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Med_341A; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_admin__3213E83F5BE50C9F");

            entity.ToTable("m_admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BiodataId).HasColumnName("biodata_id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
        });

        modelBuilder.Entity<MBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_bank__3213E83F41793FD9");

            entity.ToTable("m_bank");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.VaCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("va_code");
        });

        modelBuilder.Entity<MBiodataAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83FB6CE4106");

            entity.ToTable("m_biodata_address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.BiodataId).HasColumnName("biodata_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.Label)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("label");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.Recipent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("recipent");
            entity.Property(e => e.RecipentPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("recipent_phone_number");
        });

        modelBuilder.Entity<MBiodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83FB425FAEA");

            entity.ToTable("m_biodata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_path");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mobile_phone");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
        });

        modelBuilder.Entity<MBloodGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_blood___3213E83FB4F80D80");

            entity.ToTable("m_blood_group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
        });

        modelBuilder.Entity<MCourier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_courie__3213E83F87406629");

            entity.ToTable("m_courier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MCourierType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_courie__3213E83FFD67A6AD");

            entity.ToTable("m_courier_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourierId).HasColumnName("courier_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83FA3E40E2A");

            entity.ToTable("m_customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BiodataId).HasColumnName("biodata_id");
            entity.Property(e => e.BloodGroupId).HasColumnName("blood_group_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("height");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.RhesusType)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("rhesus_type");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("weight");
        });

        modelBuilder.Entity<MCustomerMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83F1803CB1E");

            entity.ToTable("m_customer_member");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerRelationId).HasColumnName("customer_relation_id");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.ParentBiodataId).HasColumnName("parent_biodata_id");
        });

        modelBuilder.Entity<MCustomerRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83FED1A7042");

            entity.ToTable("m_customer_relation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<MDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_doctor__3213E83F69E42855");

            entity.ToTable("m_doctor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BiodataId).HasColumnName("biodata_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Str)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("str");
        });

        modelBuilder.Entity<TCourierDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_courie__3213E83F87941E28");

            entity.ToTable("t_courier_discount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourierTypeId).HasColumnName("courier_type_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");
            entity.Property(e => e.DeletedOn)
                .HasColumnType("datetime")
                .HasColumnName("deleted_on");
            entity.Property(e => e.IsDelete).HasColumnName("is_delete");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("modified_on");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
