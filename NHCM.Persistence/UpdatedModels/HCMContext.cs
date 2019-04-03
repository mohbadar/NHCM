using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NHCM.Persistence.UpdatedModels
{
    public partial class HCMContext : DbContext
    {
        public HCMContext()
        {
        }

        /// <summary>
        ///  New Updated Models of the system
        /// </summary>
        /// <param name="options"></param>

        public HCMContext(DbContextOptions<HCMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
       
        public virtual DbSet<AssessmentLevel> AssessmentLevel { get; set; }
        public virtual DbSet<AssessmentRules> AssessmentRules { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<Characteristic> Characteristic { get; set; }
        public virtual DbSet<CharacteristicResult> CharacteristicResult { get; set; }
        public virtual DbSet<ComplainType> ComplainType { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Direction> Direction { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<EducationLevel> EducationLevel { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<EvaluationMark> EvaluationMark { get; set; }
        public virtual DbSet<EvaluationType> EvaluationType { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventLock> EventLock { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<ExamType> ExamType { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<ExperienceType> ExperienceType { get; set; }
        public virtual DbSet<Expertise> Expertise { get; set; }
        public virtual DbSet<ExternalRelationship> ExternalRelationship { get; set; }
        public virtual DbSet<FileLocation> FileLocation { get; set; }
        public virtual DbSet<FundLevel> FundLevel { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Habit> Habit { get; set; }
        public virtual DbSet<HealthReport> HealthReport { get; set; }
        public virtual DbSet<HealthReportTopic> HealthReportTopic { get; set; }
        public virtual DbSet<IdCard> IdCard { get; set; }
        public virtual DbSet<IdentificationType> IdentificationType { get; set; }
        public virtual DbSet<Indicator> Indicator { get; set; }
        public virtual DbSet<Institute> Institute { get; set; }
        public virtual DbSet<InstituteType> InstituteType { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LeaveType> LeaveType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<MilitaryService> MilitaryService { get; set; }
        public virtual DbSet<MilitaryServiceType> MilitaryServiceType { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<ObjectLevel> ObjectLevel { get; set; }
        public virtual DbSet<ObjectType> ObjectType { get; set; }
        public virtual DbSet<Observation> Observation { get; set; }
        public virtual DbSet<OffDutyReason> OffDutyReason { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<OrgUnit> OrgUnit { get; set; }
        public virtual DbSet<OrgUnitChange> OrgUnitChange { get; set; }
        public virtual DbSet<OrgUnitType> OrgUnitType { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<OrganoGram> OrganoGram { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAsset> PersonAsset { get; set; }
        public virtual DbSet<PersonCharacteristic> PersonCharacteristic { get; set; }
        public virtual DbSet<PersonDocument> PersonDocument { get; set; }
        public virtual DbSet<PersonIdentification> PersonIdentification { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        public virtual DbSet<PersonSkill> PersonSkill { get; set; }
        public virtual DbSet<PlanType> PlanType { get; set; }
        public virtual DbSet<PoliticalRelation> PoliticalRelation { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PositionChange> PositionChange { get; set; }
        public virtual DbSet<PositionRequirements> PositionRequirements { get; set; }
        public virtual DbSet<PositionResponsibility> PositionResponsibility { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<ProcessTracking> ProcessTracking { get; set; }
        public virtual DbSet<ProgramType> ProgramType { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<PublicationType> PublicationType { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<ReferenceType> ReferenceType { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<Relative> Relative { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Retirement> Retirement { get; set; }
        public virtual DbSet<RewardType> RewardType { get; set; }
        public virtual DbSet<SalaryType> SalaryType { get; set; }
        public virtual DbSet<Screens> Screens { get; set; }
        public virtual DbSet<Selection> Selection { get; set; }
        public virtual DbSet<SkillType> SkillType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<ViolationType> ViolationType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=HCM; Username=postgres; password=kasperskyantigeral;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.address_id_seq'::regclass)");

                entity.Property(e => e.Address1)
                    .HasColumnName("Address")
                    .HasMaxLength(250);

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.CdistrictId).HasColumnName("CDistrictID");

                entity.Property(e => e.ClocationId).HasColumnName("CLocationID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cvillage)
                    .HasColumnName("CVillage")
                    .HasMaxLength(400);

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.HouseNo).HasMaxLength(50);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Paddress)
                    .HasColumnName("PAddress")
                    .HasMaxLength(400);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.StreetNo).HasMaxLength(150);

                entity.Property(e => e.Village).HasMaxLength(400);
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("AddressType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.addresstype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasColumnType("char");
            });

           

            modelBuilder.Entity<AssessmentLevel>(entity =>
            {
                entity.ToTable("AssessmentLevel", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('look.assessmentlevel_id_seq'::regclass)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssessmentRules>(entity =>
            {
                entity.ToTable("AssessmentRules", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('look.assessmentrules_id_seq'::regclass)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.ToTable("AssetType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.assettype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_assettype_assettype");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("BloodGroup", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("pk_candidate");

                entity.ToTable("Candidate", "rec");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Request).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certification", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.certification_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillTypeID");

                entity.HasOne(d => d.SkillType)
                    .WithMany(p => p.Certification)
                    .HasForeignKey(d => d.SkillTypeId)
                    .HasConstraintName("fk_certification_skilltype");
            });

            modelBuilder.Entity<Characteristic>(entity =>
            {
                entity.ToTable("Characteristic", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CharacteristicResult>(entity =>
            {
                entity.ToTable("CharacteristicResult", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.characteristicresult_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ComplainType>(entity =>
            {
                entity.ToTable("ComplainType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.complaintype_id_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Component", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.component_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.course_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.currency_id_seq'::regclass)");

                entity.Property(e => e.Dari).HasMaxLength(50);
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.ToTable("Direction", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.direction_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.\"DocumentType_ID_seq\"'::regclass)");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("Documents", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('dbo.documents_id_seq'::regclass)");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EncryptionKey).HasMaxLength(120);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastDownloadDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ObjectName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ObjectSchema)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.RecordId)
                    .IsRequired()
                    .HasColumnName("RecordID")
                    .HasMaxLength(200);

                entity.Property(e => e.ReferenceNo).HasMaxLength(14);

                entity.Property(e => e.Root)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ScreenId).HasColumnName("ScreenID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.UploadDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.education_id_seq'::regclass)");

                entity.Property(e => e.Course).HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Department).HasMaxLength(200);

                entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");

                entity.Property(e => e.Enddate).HasColumnType("date");

                entity.Property(e => e.Faculty).HasMaxLength(200);

                entity.Property(e => e.Institute).HasMaxLength(200);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Major).HasMaxLength(200);

                entity.Property(e => e.MigratedLocation).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.OfficialDocumentNo).HasMaxLength(50);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(300);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.EducationLevel)
                    .WithMany(p => p.Education)
                    .HasForeignKey(d => d.EducationLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_education_educationlevel");
            });

            modelBuilder.Entity<EducationLevel>(entity =>
            {
                entity.ToTable("EducationLevel", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.educationlevel_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Parentid).HasColumnName("parentid");

                entity.Property(e => e.Sorter).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("pk_employee");

                entity.ToTable("Employee", "pol");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Day).HasDefaultValueSql("0");

                entity.Property(e => e.EmploymentStatusId).HasColumnName("EmploymentStatusID");

                entity.Property(e => e.FirstHireDate).HasColumnType("date");

                entity.Property(e => e.LastPromotionDate).HasColumnType("date");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Month).HasDefaultValueSql("0");

                entity.Property(e => e.OrgUnitId)
                    .HasColumnName("OrgUnitID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("numeric");

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Year).HasDefaultValueSql("0");

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.OrgUnitId)
                    .HasConstraintName("fk_employee_orgunitid");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("fk_employee_position");
            });

            modelBuilder.Entity<EmploymentStatus>(entity =>
            {
                entity.ToTable("EmploymentStatus", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.employmentstatus_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ethnicity>(entity =>
            {
                entity.ToTable("Ethnicity", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.ethnicity_id_seq'::regclass)");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<EvaluationMark>(entity =>
            {
                entity.ToTable("EvaluationMark", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.evaluationmark_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EvaluationType>(entity =>
            {
                entity.ToTable("EvaluationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.evaluationtype_id_seq'::regclass)");

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pashto).HasMaxLength(50);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "pol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('pol.event_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DocumentNo).HasMaxLength(50);

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<EventLock>(entity =>
            {
                entity.ToTable("EventLock", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.eventlock_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.eventtype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_eventtype_eventtype");
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.ToTable("ExamType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.experience_id_seq'::regclass)");

                entity.Property(e => e.ContactInfo).HasMaxLength(250);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DocumentNo).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ExperienceTypeId).HasColumnName("ExperienceTypeID");

                entity.Property(e => e.JobDescription).HasMaxLength(500);

                entity.Property(e => e.JobstatusId).HasColumnName("JobstatusID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<ExperienceType>(entity =>
            {
                entity.ToTable("ExperienceType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dari).HasMaxLength(50);
            });

            modelBuilder.Entity<Expertise>(entity =>
            {
                entity.ToTable("Expertise", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.expertise_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExternalRelationship>(entity =>
            {
                entity.ToTable("ExternalRelationship", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.externalrelationship_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FileLocation>(entity =>
            {
                entity.ToTable("FileLocation", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.filelocation_id_seq'::regclass)");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(200);
            });

            modelBuilder.Entity<FundLevel>(entity =>
            {
                entity.ToTable("FundLevel", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.fundlevel_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Dari).HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Pashto).HasMaxLength(30);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.gender_id_seq'::regclass)");

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto).HasMaxLength(50);
            });

            modelBuilder.Entity<Habit>(entity =>
            {
                entity.ToTable("Habit", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.habit_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HealthReport>(entity =>
            {
                entity.ToTable("HealthReport", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.healthreport_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(1200);

                entity.Property(e => e.ReportDate).HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.HealthReport)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_healthreport_person");
            });

            modelBuilder.Entity<HealthReportTopic>(entity =>
            {
                entity.ToTable("HealthReportTopic", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.healthreporttopic_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<IdCard>(entity =>
            {
                entity.ToTable("IdCard", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.idcard_id_seq'::regclass)");

                entity.Property(e => e.CardClassType).HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.IdCard)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idcard_person");
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.ToTable("IdentificationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.identificationtype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Indicator>(entity =>
            {
                entity.ToTable("Indicator", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.indicator_id_seq'::regclass)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Pashto)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.ToTable("Institute", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_institute_institute1");
            });

            modelBuilder.Entity<InstituteType>(entity =>
            {
                entity.ToTable("InstituteType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.institutetype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.ToTable("JobStatus", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.jobstatus_id_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.ToTable("Label", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(150)
                    .ValueGeneratedNever();

                entity.Property(e => e.Dari).HasMaxLength(150);

                entity.Property(e => e.English)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Pastho).HasMaxLength(150);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.language_id_seq'::regclass)");

                entity.Property(e => e.Category).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.ToTable("LeaveType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.leavetype_id_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.location_id_seq'::regclass)");

                entity.Property(e => e.Code).HasColumnType("character(3)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Path).HasMaxLength(255);

                entity.Property(e => e.PathDari)
                    .HasColumnName("Path_Dari")
                    .HasMaxLength(255);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.major_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.TrainingTypeId).HasColumnName("TrainingTypeID");

                entity.HasOne(d => d.TrainingType)
                    .WithMany(p => p.Major)
                    .HasForeignKey(d => d.TrainingTypeId)
                    .HasConstraintName("fk_major_trainingtype");
            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {
                entity.ToTable("MaritalStatus", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.maritalstatus_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MilitaryService>(entity =>
            {
                entity.ToTable("MilitaryService", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('rec.militaryservice_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MilitaryServiceTypeId).HasColumnName("MilitaryServiceTypeID");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.MilitaryServiceType)
                    .WithMany(p => p.MilitaryService)
                    .HasForeignKey(d => d.MilitaryServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_militaryservicetype_militaryservice");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.MilitaryService)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_person_militaryservice");
            });

            modelBuilder.Entity<MilitaryServiceType>(entity =>
            {
                entity.ToTable("MilitaryServiceType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.nationality_id_seq'::regclass)");

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pastho).HasMaxLength(50);
            });

            modelBuilder.Entity<ObjectLevel>(entity =>
            {
                entity.ToTable("ObjectLevel", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.objectlevel_id_seq'::regclass)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ObjectType>(entity =>
            {
                entity.ToTable("ObjectType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.objecttype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Observation>(entity =>
            {
                entity.ToTable("Observation", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.observation_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<OffDutyReason>(entity =>
            {
                entity.ToTable("OffDutyReason", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.offdutyreason_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("OrderType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.ordertype_id_seq'::regclass)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<OrgUnit>(entity =>
            {
                entity.ToTable("OrgUnit", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('org.orgunit_id_seq'::regclass)");

                entity.Property(e => e.Code).HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrganOgramId).HasColumnName("OrganOgramID");

                entity.Property(e => e.OrgunitTypeId).HasColumnName("OrgunitTypeID");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(14);

                entity.Property(e => e.Sorter).HasMaxLength(300);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.OrganOgram)
                    .WithMany(p => p.OrgUnit)
                    .HasForeignKey(d => d.OrganOgramId)
                    .HasConstraintName("fk_orgunit_organogram");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_orgunit_orgunit");
            });

            modelBuilder.Entity<OrgUnitChange>(entity =>
            {
                entity.ToTable("OrgUnitChange", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('org.orgunitchange_id_seq'::regclass)");

                entity.Property(e => e.IsAddition)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NeworgUnitId)
                    .HasColumnName("NeworgUnitID")
                    .HasColumnType("numeric");

                entity.Property(e => e.OrgUnitId)
                    .HasColumnName("OrgUnitID")
                    .HasColumnType("numeric");

                entity.Property(e => e.OrganogramId).HasColumnName("OrganogramID");

                entity.Property(e => e.PlanTypeId).HasColumnName("PlanTypeID");

                entity.HasOne(d => d.NeworgUnit)
                    .WithMany(p => p.OrgUnitChangeNeworgUnit)
                    .HasForeignKey(d => d.NeworgUnitId)
                    .HasConstraintName("fk_orgunitchange_orgunit1");

                entity.HasOne(d => d.OrgUnit)
                    .WithMany(p => p.OrgUnitChangeOrgUnit)
                    .HasForeignKey(d => d.OrgUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orgunitchange_orgunit");

                entity.HasOne(d => d.Organogram)
                    .WithMany(p => p.OrgUnitChange)
                    .HasForeignKey(d => d.OrganogramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orgunitchange_organogram");
            });

            modelBuilder.Entity<OrgUnitType>(entity =>
            {
                entity.ToTable("OrgUnitType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.orgunittype_id_seq'::regclass)");

                entity.Property(e => e.Ishead)
                    .HasColumnName("ishead")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Parentid).HasColumnName("parentid");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('dbo.organization_id_seq'::regclass)");

                entity.Property(e => e.AndssectorId).HasColumnName("ANDSSectorID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrganizationTypeId).HasColumnName("OrganizationTypeID");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Pashto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Sorter).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<OrganizationType>(entity =>
            {
                entity.ToTable("OrganizationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.organizationtype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrganoGram>(entity =>
            {
                entity.ToTable("OrganoGram", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('org.organogram_id_seq'::regclass)");

                entity.Property(e => e.AppreovedDate).HasColumnType("date");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.PreparedDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner", "pol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('pol.owner_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrgUnitId).HasColumnName("OrgUnitID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(14);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_owner_owner");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Owner)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_owner_status");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.person_id_seq'::regclass)");

                entity.Property(e => e.BirthLocationId).HasColumnName("BirthLocationID");

                entity.Property(e => e.BloodGroupId).HasColumnName("BloodGroupID");

                entity.Property(e => e.Comments).HasMaxLength(400);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DateOfBirth).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.EthnicityId).HasColumnName("EthnicityID");

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(90);

                entity.Property(e => e.FatherNameEng).HasMaxLength(90);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(90);

                entity.Property(e => e.FirstNameEng).HasMaxLength(90);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GrandFatherName).HasMaxLength(90);

                entity.Property(e => e.GrandFatherNameEng).HasMaxLength(90);

                entity.Property(e => e.HashKey).HasMaxLength(32);

                entity.Property(e => e.Hiringofficenumber)
                    .HasColumnName("hiringofficenumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Hrcode).HasMaxLength(90);

                entity.Property(e => e.LastName).HasMaxLength(90);

                entity.Property(e => e.LastNameEng).HasMaxLength(90);

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Nid)
                    .HasColumnName("NID")
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoPath).HasMaxLength(200);

                entity.Property(e => e.PreFix).HasMaxLength(14);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("Person_DocumentTypeID_fkey");
            });

            modelBuilder.Entity<PersonAsset>(entity =>
            {
                entity.ToTable("PersonAsset", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.personasset_id_seq'::regclass)");

                entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Value).HasColumnType("numeric");

                //entity.HasOne(d => d.AssetType)
                //    .WithMany(p => p.PersonAsset)
                //    .HasForeignKey(d => d.AssetTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("fk_personasset_assettype");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonAsset)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personasset_person");
            });

            modelBuilder.Entity<PersonCharacteristic>(entity =>
            {
                entity.ToTable("PersonCharacteristic", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Characteristic)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Value).HasMaxLength(200);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonCharacteristic)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personcharacteristic_person");
            });

            modelBuilder.Entity<PersonDocument>(entity =>
            {
                entity.ToTable("PersonDocument", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('rec.\"PersonDocument_ID_seq\"'::regclass)");

                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeID");

                entity.Property(e => e.Path).HasMaxLength(200);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.PersonDocument)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("PersonDocument_DocumentTypeID_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonDocument)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("PersonDocument_PersonID_fkey");
            });

            modelBuilder.Entity<PersonIdentification>(entity =>
            {
                entity.ToTable("PersonIdentification", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.personidentification_id_seq'::regclass)");

                entity.Property(e => e.BookNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Expiration).HasColumnType("date");

                entity.Property(e => e.Idno)
                    .HasColumnName("IDNo")
                    .HasMaxLength(50);

                entity.Property(e => e.IssuedOn).HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PageNumber).HasMaxLength(50);

                entity.Property(e => e.PassportExpiresOn).HasColumnType("date");

                entity.Property(e => e.PassportIdno)
                    .HasColumnName("PassportIDNo")
                    .HasMaxLength(50);

                entity.Property(e => e.PassportIssuedOn).HasColumnType("date");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.RegisterNumber).HasMaxLength(50);

                entity.Property(e => e.RegistrationNumber).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(300);

                entity.Property(e => e.TazkraIssueDate).HasColumnType("date");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.PersonIdentification)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("fk_personidentification_identificationtype");
            });

            modelBuilder.Entity<PersonLanguage>(entity =>
            {
                entity.ToTable("PersonLanguage", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.personlanguage_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.PersonLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personlanguage_language");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonLanguage)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personlanguage_person");

                entity.HasOne(d => d.ReadingExpertiseNavigation)
                    .WithMany(p => p.PersonLanguageReadingExpertiseNavigation)
                    .HasForeignKey(d => d.ReadingExpertise)
                    .HasConstraintName("fk_personlanguage_expertise");

                entity.HasOne(d => d.SpeakingExpertiseNavigation)
                    .WithMany(p => p.PersonLanguageSpeakingExpertiseNavigation)
                    .HasForeignKey(d => d.SpeakingExpertise)
                    .HasConstraintName("fk_personlanguage_expertise3");

                entity.HasOne(d => d.UnderstandingExpertiseNavigation)
                    .WithMany(p => p.PersonLanguageUnderstandingExpertiseNavigation)
                    .HasForeignKey(d => d.UnderstandingExpertise)
                    .HasConstraintName("fk_personlanguage_expertise1");

                entity.HasOne(d => d.WritingExpertiseNavigation)
                    .WithMany(p => p.PersonLanguageWritingExpertiseNavigation)
                    .HasForeignKey(d => d.WritingExpertise)
                    .HasConstraintName("fk_personlanguage_expertise2");
            });

            modelBuilder.Entity<PersonSkill>(entity =>
            {
                entity.ToTable("PersonSkill", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.personskill_id_seq'::regclass)");

                entity.Property(e => e.CertificationDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CertificationId).HasColumnName("certificationID");

                entity.Property(e => e.CertifiedFrom).HasMaxLength(200);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.EndDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ExpertiseId).HasColumnName("ExpertiseID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.StartDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonSkill)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personskill_person");
            });

            modelBuilder.Entity<PlanType>(entity =>
            {
                entity.ToTable("PlanType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<PoliticalRelation>(entity =>
            {
                entity.ToTable("PoliticalRelation", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.politicalrelation_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('org.position_id_seq'::regclass)");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DirectorateId).HasColumnName("DirectorateID");

                entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");

                entity.Property(e => e.Kadr).HasMaxLength(50);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrganoGramId).HasColumnName("OrganoGramID");

                entity.Property(e => e.OrgunitId)
                    .HasColumnName("OrgunitID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PlanTypeId).HasColumnName("PlanTypeID");

                entity.Property(e => e.PositionResponsibilityAndPurpose).HasMaxLength(600);

                entity.Property(e => e.PositionTypeId).HasColumnName("PositionTypeID");

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(14);

                entity.Property(e => e.Remarks).HasMaxLength(300);

                entity.Property(e => e.SalaryTypeId).HasColumnName("SalaryTypeID");

                entity.Property(e => e.Sorter).HasMaxLength(300);

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasDefaultValueSql("21");

                entity.Property(e => e.TransferPositionId)
                    .HasColumnName("TransferPositionID")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_position_position");
            });

            modelBuilder.Entity<PositionChange>(entity =>
            {
                entity.ToTable("PositionChange", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('org.positionchange_id_seq'::regclass)");

                entity.Property(e => e.IsAddition)
                    .IsRequired()
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NewPositionId)
                    .HasColumnName("NewPositionID")
                    .HasColumnType("numeric");

                entity.Property(e => e.OrganogramId).HasColumnName("OrganogramID");

                entity.Property(e => e.PlanTypeId).HasColumnName("PlanTypeID");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Organogram)
                    .WithMany(p => p.PositionChange)
                    .HasForeignKey(d => d.OrganogramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_positionchange_organogram");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PositionChange)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_positionchange_position");
            });

            modelBuilder.Entity<PositionRequirements>(entity =>
            {
                entity.ToTable("PositionRequirements", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('org.positionrequirements_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.EducationLevelId).HasColumnName("EducationLevelID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);
            });

            modelBuilder.Entity<PositionResponsibility>(entity =>
            {
                entity.ToTable("PositionResponsibility", "org");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('org.positionresponsibility_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Modifiedby)
                    .IsRequired()
                    .HasColumnName("modifiedby")
                    .HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(350);

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PositionResponsibility)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_positionresponsibility_position1");
            });

            modelBuilder.Entity<PositionType>(entity =>
            {
                entity.ToTable("PositionType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.positiontype_id_seq'::regclass)");

                entity.Property(e => e.IsUnit).HasDefaultValueSql("false");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrgUnitTypeId).HasColumnName("OrgUnitTypeID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.RankId).HasColumnName("RankID");
            });

            modelBuilder.Entity<ProcessTracking>(entity =>
            {
                entity.ToTable("ProcessTracking", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('dbo.processtracking_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.ReferedProcessId).HasColumnName("ReferedProcessID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<ProgramType>(entity =>
            {
                entity.ToTable("ProgramType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.programtype_id_seq'::regclass)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.ToTable("ProjectType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.projecttype_id_seq'::regclass)");

                entity.Property(e => e.Dari)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Pashto).HasMaxLength(100);
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotion", "pol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('pol.promotion_id_seq'::regclass)");

                entity.Property(e => e.Characteristic).HasMaxLength(1000);

                entity.Property(e => e.CharacteristicResultId).HasColumnName("CharacteristicResultID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasColumnType("numeric");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PresidentialOrderDate).HasColumnType("date");

                entity.Property(e => e.PresidentialOrderNo).HasMaxLength(50);

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(400);

                entity.Property(e => e.SupervisorId)
                    .HasColumnName("SupervisorID")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Promotion)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_promotion_person");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publication", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.publication_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Isbn).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PublicationTypeId).HasColumnName("PublicationTypeID");

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Publication)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publication_person");

                entity.HasOne(d => d.PublicationType)
                    .WithMany(p => p.Publication)
                    .HasForeignKey(d => d.PublicationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publication_publicationtype");
            });

            modelBuilder.Entity<PublicationType>(entity =>
            {
                entity.ToTable("PublicationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.publicationtype_id_seq'::regclass)");

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Pashto).HasMaxLength(50);
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("Rank", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.rank_id_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.RankNumber).HasMaxLength(10);

                entity.Property(e => e.Sorter).HasMaxLength(100);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.ToTable("Reference", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.reference_id_seq'::regclass)");

                entity.Property(e => e.Amount).HasMaxLength(100);

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.DocumentDate).HasColumnType("date");

                entity.Property(e => e.DocumentNumber).HasMaxLength(100);

                entity.Property(e => e.FatherName).HasMaxLength(40);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GrandFatherName).HasMaxLength(40);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Occupation).HasMaxLength(150);

                entity.Property(e => e.Organization).HasMaxLength(150);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReceiptNumber).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.ReferenceTypeId).HasColumnName("ReferenceTypeID");

                entity.Property(e => e.RelationShip).HasMaxLength(100);

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.TelephoneNo).HasMaxLength(50);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Reference)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("fk_bank_reference");

                entity.HasOne(d => d.ReferenceType)
                    .WithMany(p => p.Reference)
                    .HasForeignKey(d => d.ReferenceTypeId)
                    .HasConstraintName("fk_referencetype_reference");
            });

            modelBuilder.Entity<ReferenceType>(entity =>
            {
                entity.ToTable("ReferenceType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.referencetype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.ToTable("Relationship", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.relationship_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Relative>(entity =>
            {
                entity.ToTable("Relative", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.relative_id_seq'::regclass)");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ContactInfo).HasMaxLength(250);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CurrentLocationId).HasColumnName("CurrentLocationID");

                entity.Property(e => e.CurrentVillage).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.GrandFatherName).HasMaxLength(40);

                entity.Property(e => e.JobLocation).HasMaxLength(400);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.NidNo).HasMaxLength(14);

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PersonalProperty).HasMaxLength(250);

                entity.Property(e => e.Profession).HasMaxLength(100);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.RelationShipId).HasColumnName("RelationShipID");

                entity.Property(e => e.ReligionId).HasColumnName("ReligionID");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Village).HasMaxLength(50);

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Relative)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("fk_relative_religion");
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.ToTable("Religion", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.religion_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_religion_religion");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.result_id_seq'::regclass)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnType("character(2)");

                entity.Property(e => e.Dari).HasColumnType("character(50)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto).HasColumnType("character(50)");
            });

            modelBuilder.Entity<Retirement>(entity =>
            {
                entity.ToTable("Retirement", "pol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('pol.retirement_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasColumnType("numeric");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ReasonId).HasColumnName("ReasonID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(500);
            });

            modelBuilder.Entity<RewardType>(entity =>
            {
                entity.ToTable("RewardType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('look.rewardtype_id_seq'::regclass)");

                entity.Property(e => e.BenefitForMilitaryWorker).HasMaxLength(600);

                entity.Property(e => e.BenefitForSocialWorker).HasMaxLength(600);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasDefaultValueSql("20");

                entity.Property(e => e.Type).HasDefaultValueSql("'n'::bpchar");

                entity.Property(e => e.TypeOfMetal).HasMaxLength(200);
            });

            modelBuilder.Entity<SalaryType>(entity =>
            {
                entity.ToTable("SalaryType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.salarytype_id_seq'::regclass)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pashto).HasMaxLength(50);
            });

            modelBuilder.Entity<Screens>(entity =>
            {
                entity.ToTable("Screens", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.screens_id_seq'::regclass)");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Icon).HasMaxLength(100);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Path).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("Screens_ParentID_fkey");
            });

            modelBuilder.Entity<Selection>(entity =>
            {
                entity.ToTable("Selection", "pol");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('pol.selection_id_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .HasColumnType("numeric");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.FinalNo).HasMaxLength(20);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.OldPosition).HasMaxLength(200);

                entity.Property(e => e.OrganizationId)
                    .HasColumnName("OrganizationID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("numeric");

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(400);

                entity.Property(e => e.VerdictDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.VerdictRegNo).HasMaxLength(20);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Selection)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("fk_selection_organization");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Selection)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_selection_position");
            });

            modelBuilder.Entity<SkillType>(entity =>
            {
                entity.ToTable("SkillType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.skilltype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_skilltype_skilltype");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.status_id_seq'::regclass)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasColumnType("character(2)");

                entity.Property(e => e.Dari).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pashto).HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.subject_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.ToTable("TrainingType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.trainingtype_id_seq'::regclass)");

                entity.Property(e => e.Category).HasColumnType("character(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_trainingtype_trainingtype");
            });

            modelBuilder.Entity<Travel>(entity =>
            {
                entity.ToTable("Travel", "rec");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric")
                    .HasDefaultValueSql("nextval('rec.travel_id_seq'::regclass)");

                entity.Property(e => e.AccompanyWith).HasMaxLength(200);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("numeric");

                entity.Property(e => e.Place).HasMaxLength(150);

                entity.Property(e => e.Reason).HasMaxLength(1000);

                entity.Property(e => e.ReferenceNo).HasMaxLength(200);

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.TravelDate).HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Travel)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_travel_person");
            });

            modelBuilder.Entity<ViolationType>(entity =>
            {
                entity.ToTable("ViolationType", "look");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("nextval('look.violationtype_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.HasSequence("documents_id_seq");

            modelBuilder.HasSequence("organization_id_seq");

            modelBuilder.HasSequence("processtracking_id_seq");

            modelBuilder.HasSequence("addresstype_id_seq");

            modelBuilder.HasSequence("assessmentlevel_id_seq");

            modelBuilder.HasSequence("assessmentrules_id_seq");

            modelBuilder.HasSequence("assettype_id_seq");

            modelBuilder.HasSequence("certification_id_seq");

            modelBuilder.HasSequence("characteristicresult_id_seq");

            modelBuilder.HasSequence("complaintype_id_seq");

            modelBuilder.HasSequence("component_id_seq");

            modelBuilder.HasSequence("course_id_seq");

            modelBuilder.HasSequence("currency_id_seq");

            modelBuilder.HasSequence("direction_id_seq");

            modelBuilder.HasSequence<int>("DocumentType_ID_seq");

            modelBuilder.HasSequence("educationlevel_id_seq");

            modelBuilder.HasSequence("employmentstatus_id_seq");

            modelBuilder.HasSequence("ethnicity_id_seq");

            modelBuilder.HasSequence("evaluationmark_id_seq");

            modelBuilder.HasSequence("evaluationtype_id_seq");

            modelBuilder.HasSequence("eventlock_id_seq");

            modelBuilder.HasSequence("eventtype_id_seq");

            modelBuilder.HasSequence("expertise_id_seq");

            modelBuilder.HasSequence("externalrelationship_id_seq");

            modelBuilder.HasSequence("filelocation_id_seq");

            modelBuilder.HasSequence("fundlevel_id_seq");

            modelBuilder.HasSequence("gender_id_seq");

            modelBuilder.HasSequence("habit_id_seq");

            modelBuilder.HasSequence("healthreporttopic_id_seq");

            modelBuilder.HasSequence("identificationtype_id_seq");

            modelBuilder.HasSequence("indicator_id_seq");

            modelBuilder.HasSequence("institutetype_id_seq");

            modelBuilder.HasSequence("jobstatus_id_seq");

            modelBuilder.HasSequence("language_id_seq");

            modelBuilder.HasSequence("leavetype_id_seq");

            modelBuilder.HasSequence("location_id_seq");

            modelBuilder.HasSequence("major_id_seq");

            modelBuilder.HasSequence("maritalstatus_id_seq");

            modelBuilder.HasSequence("nationality_id_seq");

            modelBuilder.HasSequence("objectlevel_id_seq");

            modelBuilder.HasSequence("objecttype_id_seq");

            modelBuilder.HasSequence("observation_id_seq");

            modelBuilder.HasSequence("offdutyreason_id_seq");

            modelBuilder.HasSequence("ordertype_id_seq");

            modelBuilder.HasSequence("organizationtype_id_seq");

            modelBuilder.HasSequence("orgunittype_id_seq");

            modelBuilder.HasSequence("politicalrelation_id_seq");

            modelBuilder.HasSequence("positiontype_id_seq");

            modelBuilder.HasSequence("programtype_id_seq");

            modelBuilder.HasSequence("projecttype_id_seq");

            modelBuilder.HasSequence("publicationtype_id_seq");

            modelBuilder.HasSequence("rank_id_seq");

            modelBuilder.HasSequence("referencetype_id_seq");

            modelBuilder.HasSequence("relationship_id_seq");

            modelBuilder.HasSequence("religion_id_seq");

            modelBuilder.HasSequence("result_id_seq");

            modelBuilder.HasSequence("rewardtype_id_seq");

            modelBuilder.HasSequence("salarytype_id_seq");

            modelBuilder.HasSequence("screens_id_seq");

            modelBuilder.HasSequence("skilltype_id_seq");

            modelBuilder.HasSequence("status_id_seq");

            modelBuilder.HasSequence("subject_id_seq");

            modelBuilder.HasSequence("trainingtype_id_seq");

            modelBuilder.HasSequence("violationtype_id_seq");

            modelBuilder.HasSequence("organogram_id_seq");

            modelBuilder.HasSequence("orgunit_id_seq");

            modelBuilder.HasSequence("orgunitchange_id_seq");

            modelBuilder.HasSequence("position_id_seq");

            modelBuilder.HasSequence("positionchange_id_seq");

            modelBuilder.HasSequence("positionrequirements_id_seq");

            modelBuilder.HasSequence("positionresponsibility_id_seq");

            modelBuilder.HasSequence("complain_id_seq");

            modelBuilder.HasSequence("event_id_seq");

            modelBuilder.HasSequence("governmenthelp_id_seq");

            modelBuilder.HasSequence("owner_id_seq");

            modelBuilder.HasSequence("promotion_id_seq");

            modelBuilder.HasSequence("punishment_id_seq");

            modelBuilder.HasSequence("retirement_id_seq");

            modelBuilder.HasSequence("selection_id_seq");

            modelBuilder.HasSequence("address_id_seq");

            modelBuilder.HasSequence("education_id_seq");

            modelBuilder.HasSequence("experience_id_seq");

            modelBuilder.HasSequence("healthreport_id_seq");

            modelBuilder.HasSequence("idcard_id_seq");

            modelBuilder.HasSequence("militaryservice_id_seq");

            modelBuilder.HasSequence("person_id_seq");

            modelBuilder.HasSequence("personasset_id_seq");

            modelBuilder.HasSequence("personcharacteristic_id_seq");

            modelBuilder.HasSequence<int>("PersonDocument_ID_seq");

            modelBuilder.HasSequence("personidentification_id_seq");

            modelBuilder.HasSequence("personlanguage_id_seq");

            modelBuilder.HasSequence("personskill_id_seq");

            modelBuilder.HasSequence("publication_id_seq");

            modelBuilder.HasSequence("reference_id_seq");

            modelBuilder.HasSequence("relative_id_seq");

            modelBuilder.HasSequence("travel_id_seq");
        }
    }
}
