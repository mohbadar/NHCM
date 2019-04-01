using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NHCM.Domain.Entities;

namespace NHCM.Persistence
{
    public partial class HCMContext : DbContext
    {
        public HCMContext()
        {
        }
        public HCMContext(DbContextOptions<HCMContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<MilitaryService> MilitaryService { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAsset> PersonAsset { get; set; }
        public virtual DbSet<PersonLanguage> PersonLanguage { get; set; }
        public virtual DbSet<PersonSkill> PersonSkill { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<Expertise> Expertise { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<Relative> Relative { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Institute> Institute { get; set; }
        public virtual DbSet<ExperienceType> ExperienceType { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<EducationLevel> EducationLevel { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<SkillType> SkillType { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<ReferenceType> ReferenceType { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Screens> Screens { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<HealthReport> HealthReport { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }
        public virtual DbSet<PublicationType> PublicationType { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<FolderPath> FolderPath { get; set; }
        public virtual DbSet<Documents> Document { get; set; }



        public virtual DbSet<Selection> Selection { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }

        public virtual DbSet<OrgUnit> OrgUnit { get; set; }
        public virtual DbSet<OrganoGram> OrganoGram { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Characteristic> Characteristic { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<PositionChange> PositionChange { get; set; }
        public virtual DbSet<PlanType> PlanType { get; set; }
        public virtual DbSet<SalaryType> SalaryType { get; set; }
        public virtual DbSet<MilitaryServiceType> MilitaryServiceType { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost; Database =HCM; Username=postgres; Password=kasperskyantigeral");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasSequence("assettype_id_seq");





            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HCMContext).Assembly);
            modelBuilder.HasSequence("expertise_id_seq");
            modelBuilder.HasSequence("documentlog_id_seq");
            modelBuilder.HasSequence("documents_id_seq");
            modelBuilder.HasSequence("organization_id_seq");
            modelBuilder.HasSequence("photo_id_seq");
            modelBuilder.HasSequence("processtracking_id_seq");
         //   modelBuilder.HasSequence("trainingparticipant_id_seq");
            modelBuilder.HasSequence("evaluation_id_seq");
            modelBuilder.HasSequence("workplan_id_seq");
            modelBuilder.HasSequence("addresstype_id_seq");
           
            modelBuilder.HasSequence("gender_id_seq");
            modelBuilder.HasSequence("institutetype_id_seq");
            modelBuilder.HasSequence("jobstatus_id_seq");
            modelBuilder.HasSequence("language_id_seq");
            modelBuilder.HasSequence("leavetype_id_seq");
            modelBuilder.HasSequence("location_id_seq");
            modelBuilder.HasSequence("major_id_seq");
            modelBuilder.HasSequence("maritalstatus_id_seq");
            modelBuilder.HasSequence("nationality_id_seq");
            modelBuilder.HasSequence("offdutyreason_id_seq");
            modelBuilder.HasSequence("organizationtype_id_seq");
            modelBuilder.HasSequence("orgunittype_id_seq");
            modelBuilder.HasSequence("politicalrelation_id_seq");
            modelBuilder.HasSequence("positiontype_id_seq");
            modelBuilder.HasSequence("rank_id_seq");
            modelBuilder.HasSequence("relationship_id_seq");
            modelBuilder.HasSequence("religion_id_seq");
            modelBuilder.HasSequence("salarytype_id_seq");
            modelBuilder.HasSequence("status_id_seq");
            modelBuilder.HasSequence("organogram_id_seq");
            modelBuilder.HasSequence("orgunit_id_seq");
            modelBuilder.HasSequence("position_id_seq");
            modelBuilder.HasSequence("positionrequirements_id_seq");
            modelBuilder.HasSequence("positionresponsibility_id_seq");
            modelBuilder.HasSequence("complain_id_seq");
            modelBuilder.HasSequence("event_id_seq");
            modelBuilder.HasSequence("governmenthelp_id_seq");
            modelBuilder.HasSequence("owner_id_seq");
            modelBuilder.HasSequence("promotion_id_seq");
            modelBuilder.HasSequence("punishment_id_seq");
            modelBuilder.HasSequence("retirement_id_seq");

            modelBuilder.HasSequence("attendance_id_seq");
            modelBuilder.HasSequence("education_id_seq");
            modelBuilder.HasSequence("employeepormotion_id_seq");
            modelBuilder.HasSequence("experience_id_seq");
            modelBuilder.HasSequence("healthreport_id_seq");
            modelBuilder.HasSequence("idcard_id_seq");
            modelBuilder.HasSequence("judgespromotion_id_seq");
            modelBuilder.HasSequence("militaryservice_id_seq");
            modelBuilder.HasSequence("person_id_seq");
            modelBuilder.HasSequence("personasset_id_seq");
            modelBuilder.HasSequence("personcharacteristic_id_seq");
            modelBuilder.HasSequence("personidentification_id_seq");
            modelBuilder.HasSequence("personlanguage_id_seq");
            modelBuilder.HasSequence("personskill_id_seq");
            modelBuilder.HasSequence("publication_id_seq");
            modelBuilder.HasSequence("result_id_seq");
            modelBuilder.HasSequence<int>("FolderPath_ID_seq");
            modelBuilder.HasSequence("relative_id_seq");
            modelBuilder.HasSequence("publicationtype_id_seq");
            modelBuilder.HasSequence("reference_id_seq");
            modelBuilder.HasSequence("referencetype_id_seq");
            modelBuilder.HasSequence("travel_id_seq");
            modelBuilder.HasSequence("certification_id_seq");
            modelBuilder.HasSequence("ethnicity_id_seq");
            modelBuilder.HasSequence("skilltype_id_seq");
            modelBuilder.HasSequence("screens_id_seq");
            modelBuilder.HasSequence("educationlevel_id_seq");

            modelBuilder.HasSequence("selection_id_seq");
            modelBuilder.HasSequence("eventtype_id_seq");

            modelBuilder.HasSequence<int>("DocumentType_ID_seq");
        }
    }
}
