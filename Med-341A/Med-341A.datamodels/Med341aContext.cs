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
            entity.HasKey(e => e.Id).HasName("PK__m_admin__3213E83F59AB3BE3");
        });

        modelBuilder.Entity<MBank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_bank__3213E83F04F31EF0");
        });

        modelBuilder.Entity<MBiodataAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83F53EC9EA3");
        });

        modelBuilder.Entity<MBiodataAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83FC93AE946");
        });

        modelBuilder.Entity<MBiodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_biodat__3213E83FBED4C8E7");
        });

        modelBuilder.Entity<MBloodGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_blood___3213E83F90DDE2C3");
        });

        modelBuilder.Entity<MCourier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_courie__3213E83FA11418F2");
        });

        modelBuilder.Entity<MCourierType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_courie__3213E83F38AEB480");
        });

        modelBuilder.Entity<MCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83F103512FE");
        });

        modelBuilder.Entity<MCustomerMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83F9BBA1B5A");
        });

        modelBuilder.Entity<MCustomerRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_custom__3213E83F890206BB");
        });

        modelBuilder.Entity<MDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_doctor__3213E83F7D718851");
        });

        modelBuilder.Entity<MDoctorEducation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_doctor__3213E83F44B2B8EE");

            entity.Property(e => e.IsLastEducation).HasDefaultValue(false);
        });

        modelBuilder.Entity<MEducationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_educat__3213E83F9C78F7A2");
        });

        modelBuilder.Entity<MLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_locati__3213E83F43166E99");
        });

        modelBuilder.Entity<MLocationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_locati__3213E83F55B245A7");
        });

        modelBuilder.Entity<MMedicalFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FF52229AA");
        });

        modelBuilder.Entity<MMedicalFacilityCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FE7E55C0D");
        });

        modelBuilder.Entity<MMedicalFacilitySchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FB25869E1");
        });

        modelBuilder.Entity<MMedicalItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83F2E0416CE");
        });

        modelBuilder.Entity<MMedicalItemCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FA9BB83AE");
        });

        modelBuilder.Entity<MMedicalItemSegmentation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_medica__3213E83FD92E333D");
        });

        modelBuilder.Entity<MMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_menu__3213E83F98ECE147");
        });

        modelBuilder.Entity<MMenuRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_menu_r__3213E83F579FEAF8");
        });

        modelBuilder.Entity<MPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_paymen__3213E83F7DD79E79");
        });

        modelBuilder.Entity<MRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_role__3213E83FDDC73EDB");
        });

        modelBuilder.Entity<MSpecialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_specia__3213E83F4F1D13CE");
        });

        modelBuilder.Entity<MUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_user__3213E83FC888DCEA");
        });

        modelBuilder.Entity<MWalletDefaultNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__m_wallet__3213E83FF12CA286");
        });

        modelBuilder.Entity<TAppointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83FFEE083D2");
        });

        modelBuilder.Entity<TAppointmentCancellation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F8BB5E48D");
        });

        modelBuilder.Entity<TAppointmentDone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F14FB12AC");
        });

        modelBuilder.Entity<TAppointmentRescheduleHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_appoin__3213E83F9425F9C8");
        });

        modelBuilder.Entity<TCourierDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_courie__3213E83F7F6B720A");
        });

        modelBuilder.Entity<TCurrentDoctorSpecialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_curren__3213E83F98CCE984");
        });

        modelBuilder.Entity<TCustomerChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83FB7C0F4E8");
        });

        modelBuilder.Entity<TCustomerChatHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F21C9AE47");
        });

        modelBuilder.Entity<TCustomerChatNominal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F18150402");
        });

        modelBuilder.Entity<TCustomerRegisteredCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F214BA7ED");
        });

        modelBuilder.Entity<TCustomerVa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83FAE2F4AC1");
        });

        modelBuilder.Entity<TCustomerVaHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F1241481E");
        });

        modelBuilder.Entity<TCustomerWallet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83F2D7EB22C");

            entity.Property(e => e.IsBlocked).HasDefaultValue(false);
        });

        modelBuilder.Entity<TCustomerWalletTopup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83FC0C6374F");
        });

        modelBuilder.Entity<TCustomerWalletWithdraw>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_custom__3213E83FE173D058");
        });

        modelBuilder.Entity<TDoctorOffice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F5FD8AA25");
        });

        modelBuilder.Entity<TDoctorOfficeSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F9C961BFB");
        });

        modelBuilder.Entity<TDoctorOfficeTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F49844F51");
        });

        modelBuilder.Entity<TDoctorTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_doctor__3213E83F1A89990E");
        });

        modelBuilder.Entity<TMedicalItemPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_medica__3213E83F04653190");
        });

        modelBuilder.Entity<TMedicalItemPurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_medica__3213E83F43BFD694");
        });

        modelBuilder.Entity<TResetPassword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_reset___3213E83F63BE2EA3");
        });

        modelBuilder.Entity<TToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_token__3213E83F21859B9E");
        });

        modelBuilder.Entity<TTreatmentDiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__t_treatm__3213E83F1F10C995");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
