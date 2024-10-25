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

    public virtual DbSet<MBiodataAttachment> MBiodataAttachments { get; set; }

    public virtual DbSet<MBiodatum> MBiodata { get; set; }

    public virtual DbSet<MBloodGroup> MBloodGroups { get; set; }

    public virtual DbSet<MCourier> MCouriers { get; set; }

    public virtual DbSet<MCourierType> MCourierTypes { get; set; }

    public virtual DbSet<MCustomer> MCustomers { get; set; }

    public virtual DbSet<MCustomerMember> MCustomerMembers { get; set; }

    public virtual DbSet<MCustomerRelation> MCustomerRelations { get; set; }

    public virtual DbSet<MDoctor> MDoctors { get; set; }

    public virtual DbSet<MDoctorEducation> MDoctorEducations { get; set; }

    public virtual DbSet<MEducationLevel> MEducationLevels { get; set; }

    public virtual DbSet<MLocation> MLocations { get; set; }

    public virtual DbSet<MLocationLevel> MLocationLevels { get; set; }

    public virtual DbSet<MMedicalFacility> MMedicalFacilities { get; set; }

    public virtual DbSet<MMedicalFacilityCategory> MMedicalFacilityCategories { get; set; }

    public virtual DbSet<MMedicalFacilitySchedule> MMedicalFacilitySchedules { get; set; }

    public virtual DbSet<MMedicalItem> MMedicalItems { get; set; }

    public virtual DbSet<MMedicalItemCategory> MMedicalItemCategories { get; set; }

    public virtual DbSet<MMedicalItemSegmentation> MMedicalItemSegmentations { get; set; }

    public virtual DbSet<MMenu> MMenus { get; set; }

    public virtual DbSet<MMenuRole> MMenuRoles { get; set; }

    public virtual DbSet<MPaymentMethod> MPaymentMethods { get; set; }

    public virtual DbSet<MRole> MRoles { get; set; }

    public virtual DbSet<MSpecialization> MSpecializations { get; set; }

    public virtual DbSet<MUser> MUsers { get; set; }

    public virtual DbSet<MWalletDefaultNominal> MWalletDefaultNominals { get; set; }

    public virtual DbSet<TAppointment> TAppointments { get; set; }

    public virtual DbSet<TAppointmentCancellation> TAppointmentCancellations { get; set; }

    public virtual DbSet<TAppointmentDone> TAppointmentDones { get; set; }

    public virtual DbSet<TAppointmentRescheduleHistory> TAppointmentRescheduleHistories { get; set; }

    public virtual DbSet<TCourierDiscount> TCourierDiscounts { get; set; }

    public virtual DbSet<TCurrentDoctorSpecialization> TCurrentDoctorSpecializations { get; set; }

    public virtual DbSet<TCustomerChat> TCustomerChats { get; set; }

    public virtual DbSet<TCustomerChatHistory> TCustomerChatHistories { get; set; }

    public virtual DbSet<TCustomerChatNominal> TCustomerChatNominals { get; set; }

    public virtual DbSet<TCustomerRegisteredCard> TCustomerRegisteredCards { get; set; }

    public virtual DbSet<TCustomerVa> TCustomerVas { get; set; }

    public virtual DbSet<TCustomerVaHistory> TCustomerVaHistories { get; set; }

    public virtual DbSet<TCustomerWallet> TCustomerWallets { get; set; }

    public virtual DbSet<TCustomerWalletTopup> TCustomerWalletTopups { get; set; }

    public virtual DbSet<TCustomerWalletWithdraw> TCustomerWalletWithdraws { get; set; }

    public virtual DbSet<TDoctorOffice> TDoctorOffices { get; set; }

    public virtual DbSet<TDoctorOfficeSchedule> TDoctorOfficeSchedules { get; set; }

    public virtual DbSet<TDoctorOfficeTreatment> TDoctorOfficeTreatments { get; set; }

    public virtual DbSet<TDoctorTreatment> TDoctorTreatments { get; set; }

    public virtual DbSet<TMedicalItemPurchase> TMedicalItemPurchases { get; set; }

    public virtual DbSet<TMedicalItemPurchaseDetail> TMedicalItemPurchaseDetails { get; set; }

    public virtual DbSet<TResetPassword> TResetPasswords { get; set; }

    public virtual DbSet<TToken> TTokens { get; set; }

    public virtual DbSet<TTreatmentDiscount> TTreatmentDiscounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Initial Catalog=Med_341A; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_admin__3213E83F3B19BA22");
        });

        modelBuilder.Entity<MBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_bank__3213E83FDE7715C9");
        });

        modelBuilder.Entity<MBiodataAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83F8001F4AE");
        });

        modelBuilder.Entity<MBiodataAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83F2114B270");
        });

        modelBuilder.Entity<MBiodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83F493328F3");
        });

        modelBuilder.Entity<MBloodGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_blood___3213E83FDCF2CA02");
        });

        modelBuilder.Entity<MCourier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_courie__3213E83F52503D11");
        });

        modelBuilder.Entity<MCourierType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_courie__3213E83F40A3459D");
        });

        modelBuilder.Entity<MCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83F2382BF3C");
        });

        modelBuilder.Entity<MCustomerMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83FF361E05C");
        });

        modelBuilder.Entity<MCustomerRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83FB863A8D7");
        });

        modelBuilder.Entity<MDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_doctor__3213E83F2EC6AC5E");
        });

        modelBuilder.Entity<MDoctorEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_doctor__3213E83F1607D3D2");

            entity.Property(e => e.IsLastEducation).HasDefaultValue(false);
        });

        modelBuilder.Entity<MEducationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_educat__3213E83FD1229CBD");
        });

        modelBuilder.Entity<MLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_locati__3213E83F30669EDA");
        });

        modelBuilder.Entity<MLocationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_locati__3213E83F632BFECC");
        });

        modelBuilder.Entity<MMedicalFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83F0EAD19E2");
        });

        modelBuilder.Entity<MMedicalFacilityCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FBF3F5589");
        });

        modelBuilder.Entity<MMedicalFacilitySchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83F992A890F");
        });

        modelBuilder.Entity<MMedicalItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FA6FF958D");
        });

        modelBuilder.Entity<MMedicalItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FD55C1C1A");
        });

        modelBuilder.Entity<MMedicalItemSegmentation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83F916ED911");
        });

        modelBuilder.Entity<MMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_menu__3213E83FCF065DF7");
        });

        modelBuilder.Entity<MMenuRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_menu_r__3213E83F1E5E5E8D");
        });

        modelBuilder.Entity<MPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_paymen__3213E83F213DCCCA");
        });

        modelBuilder.Entity<MRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_role__3213E83FEC361E68");
        });

        modelBuilder.Entity<MSpecialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_specia__3213E83F455C4A3E");
        });

        modelBuilder.Entity<MUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_user__3213E83FF07B89AA");
        });

        modelBuilder.Entity<MWalletDefaultNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_wallet__3213E83FDF98832B");
        });

        modelBuilder.Entity<TAppointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F481B4531");
        });

        modelBuilder.Entity<TAppointmentCancellation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F971B0509");
        });

        modelBuilder.Entity<TAppointmentDone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F02B2528F");
        });

        modelBuilder.Entity<TAppointmentRescheduleHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F1C4519A3");
        });

        modelBuilder.Entity<TCourierDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_courie__3213E83F39CBD93E");
        });

        modelBuilder.Entity<TCurrentDoctorSpecialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_curren__3213E83F8BA1C01D");
        });

        modelBuilder.Entity<TCustomerChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F852D4D37");
        });

        modelBuilder.Entity<TCustomerChatHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F11BD8900");
        });

        modelBuilder.Entity<TCustomerChatNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83FBA6CE087");
        });

        modelBuilder.Entity<TCustomerRegisteredCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F6959D4A6");
        });

        modelBuilder.Entity<TCustomerVa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F4A7EF3A1");
        });

        modelBuilder.Entity<TCustomerVaHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F2DEC0C58");
        });

        modelBuilder.Entity<TCustomerWallet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F35E15196");

            entity.Property(e => e.IsBlocked).HasDefaultValue(false);
        });

        modelBuilder.Entity<TCustomerWalletTopup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F26A2D7E5");
        });

        modelBuilder.Entity<TCustomerWalletWithdraw>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F20DF43CF");
        });

        modelBuilder.Entity<TDoctorOffice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F041806CE");
        });

        modelBuilder.Entity<TDoctorOfficeSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F83489C2B");
        });

        modelBuilder.Entity<TDoctorOfficeTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83FD2AA1048");
        });

        modelBuilder.Entity<TDoctorTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F2638E072");
        });

        modelBuilder.Entity<TMedicalItemPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_medica__3213E83F67638A78");
        });

        modelBuilder.Entity<TMedicalItemPurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_medica__3213E83F87D0B335");
        });

        modelBuilder.Entity<TResetPassword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_reset___3213E83F4D6E8F7F");
        });

        modelBuilder.Entity<TToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_token__3213E83F1B228613");
        });

        modelBuilder.Entity<TTreatmentDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_treatm__3213E83F0D6CB22A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
