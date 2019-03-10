using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using NHCM.Domain.Entities;
using NHCM.Application.Lookup.Queries;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace NHCM.WebUI.Types
{
    public   class BasePage : PageModel
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());




        public List<SelectListItem> ListOfMaritalStatus = new List<SelectListItem>();
        public List<SelectListItem> ListOfGenders = new List<SelectListItem>();
        public List<SelectListItem> ListOfLocations = new List<SelectListItem>();
        public List<SelectListItem> ListOfBloodGroups = new List<SelectListItem>();
        public List<SelectListItem> ListOfEthnicities = new List<SelectListItem>();
        public List<SelectListItem> ListOfReligions = new List<SelectListItem>();
        public List<SelectListItem> ListOfLanguages = new List<SelectListItem>();
        public List<SelectListItem> ListOfJobStatus = new List<SelectListItem>();
        public List<SelectListItem> ListOfResult = new List<SelectListItem>();
        public List<SelectListItem> ListOfRanks = new List<SelectListItem>();
        public List<SelectListItem> ListOfOrganizationType = new List<SelectListItem>();
        public List<SelectListItem> ListOfCertification = new List<SelectListItem>();
        public List<SelectListItem> ListOfExperienceType = new List<SelectListItem>();
        public List<SelectListItem> ListOfRelationShip = new List<SelectListItem>();
        public List<SelectListItem> ListOfExpertise = new List<SelectListItem>();
        public List<SelectListItem> ListOfSkillType = new List<SelectListItem>();
        public List<SelectListItem> ListOfDistricts = new List<SelectListItem>();
        public List<SelectListItem> ListOfEducationLevels = new List<SelectListItem>();
        public List<SelectListItem> ListOfStatus = new List<SelectListItem>();
        public List<SelectListItem> ListOfAssetType = new List<SelectListItem>();
        public List<SelectListItem> ListOfReferenceType = new List<SelectListItem>();

        public List<SelectListItem> ListOfPublicationType = new List<SelectListItem>();

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {

            // Get Genders
            List<Gender> Genders = new List<Gender>();
            Genders = await Mediator.Send(new GetGenderQuery() { ID = null });
            foreach (Gender gender in Genders)
                ListOfGenders.Add(new SelectListItem(gender.Dari, gender.ID.ToString()));


            // Get Marital Status
            List<MaritalStatus> maritals = new List<MaritalStatus>();
            maritals = await Mediator.Send(new GetMaritalStatusQuery() { ID = null });
            foreach (MaritalStatus maritalStatus in maritals)
                ListOfMaritalStatus.Add(new SelectListItem(maritalStatus.Name, maritalStatus.Id.ToString()));


            //Get Ethnicities
            List<Ethnicity> ethnicities = new List<Ethnicity>();
            ethnicities = await Mediator.Send(new GetEthnicityQuery() { ID = null });
            foreach (Ethnicity ethnicity in ethnicities)
                ListOfEthnicities.Add(new SelectListItem(ethnicity.Name, ethnicity.Id.ToString()));


            //Get Religions

            List<Religion> religions = new List<Religion>();
            religions = await Mediator.Send(new GetReligionQuery() { ID = null });
            foreach (Religion religion in religions)
                ListOfReligions.Add(new SelectListItem(religion.Name, religion.Id.ToString()));

            //Get blood groups
            List<BloodGroup> bloodGroups = new List<BloodGroup>();
            bloodGroups = await Mediator.Send(new GetBloodGroupQuery() { ID = null });
            foreach (BloodGroup bloodGroup in bloodGroups)
                ListOfBloodGroups.Add(new SelectListItem(bloodGroup.Name, bloodGroup.Id.ToString()));

            //Get Locations
            List<Location> locations = new List<Location>();
            locations = await Mediator.Send(new GetLocationQuery() { ID = null });
            foreach (Location l in locations)
                ListOfLocations.Add(new SelectListItem(l.Dari, l.Id.ToString()));

            List<Relationship> relationships = new List<Relationship>();
            relationships = await Mediator.Send(new GetRelationshipQuery() { ID = null });
            foreach (Relationship relationship in relationships)
                ListOfRelationShip.Add(new SelectListItem() { Text = relationship.Name, Value = relationship.Id.ToString() });



            List<Language> languages = new List<Language>();
            languages = await Mediator.Send(new GetLanguageQuery() { ID = null });
            foreach (Language language in languages)
                ListOfLanguages.Add(new SelectListItem(language.Name, language.ID.ToString()));


            List<Expertise> expertises = new List<Expertise>();
            expertises = await Mediator.Send(new GetExpertiseQuery() { ID = null });
            foreach (Expertise expertise in expertises)
                ListOfExpertise.Add(new SelectListItem() { Text = expertise.Name, Value = expertise.Id.ToString() });


            List<District> districts = new List<District>();
            districts = await Mediator.Send(new GetDistrictQuery() { ID = null });
            foreach (District district in districts)
                ListOfDistricts.Add(new SelectListItem() { Text = district.Name, Value = district.Id.ToString() });


            List<EducationLevel> educationLevels = new List<EducationLevel>();
            educationLevels = await Mediator.Send(new GetEducationLevelQuery() { ID = null });
            foreach (EducationLevel level in educationLevels)
                ListOfEducationLevels.Add(new SelectListItem() { Text = level.Name, Value = level.Id.ToString() });


            List<ExperienceType> experienceTypes = new List<ExperienceType>();

            experienceTypes = await Mediator.Send(new GetExperienceTypeQuery() { ID = null });
            foreach (ExperienceType experienceType in experienceTypes)
                ListOfExperienceType.Add(new SelectListItem() { Text = experienceType.Dari, Value = experienceType.Id.ToString() });

            List<JobStatus> jobStatuses = new List<JobStatus>();
            jobStatuses = await Mediator.Send(new GetJobStatusQuery() { ID = null });
            foreach (JobStatus jobStatus in jobStatuses)
                ListOfJobStatus.Add(new SelectListItem() { Text = jobStatus.Name, Value = jobStatus.Id.ToString() });

            List<OrganizationType> organizationTypes = new List<OrganizationType>();
            organizationTypes = await Mediator.Send(new GetOrganizationTypeQuery() { ID = null });
            foreach (OrganizationType organizationType in organizationTypes)
                ListOfOrganizationType.Add(new SelectListItem() { Text = organizationType.Name, Value = organizationType.Id.ToString() });

            List<Rank> ranks = new List<Rank>();
            ranks = await Mediator.Send(new GetRankQuery() { ID = null });
            foreach (Rank rank in ranks)
                ListOfRanks.Add(new SelectListItem() { Text = rank.Name, Value = rank.Id.ToString() });


            List<NHCM.Domain.Entities.Result> results = new List<NHCM.Domain.Entities.Result>();
            results = await Mediator.Send(new GetResultQuery() { ID = null });
            foreach (NHCM.Domain.Entities.Result result in results)
                ListOfResult.Add(new SelectListItem() { Text = result.Name, Value = result.Id.ToString() });



            List<SkillType> skillTypes = new List<SkillType>();
            skillTypes = await Mediator.Send(new GetSkillTypeQuery() { ID = null });
            foreach (SkillType skillType in skillTypes)
                ListOfSkillType.Add(new SelectListItem() { Text = skillType.Name, Value = skillType.Id.ToString() });

            List<Certification> certifications = new List<Certification>();
            certifications = await Mediator.Send(new GetCertificationQuery() { ID = null });
            foreach (Certification certification in certifications)
                ListOfCertification.Add(new SelectListItem() { Text = certification.Name, Value = certification.Id.ToString() });


            List<AssetType> assetTypes = new List<AssetType>();
            assetTypes = await Mediator.Send(new GetAssetTypeQuery() { ID = null });
            foreach (AssetType assetType in assetTypes)
                ListOfAssetType.Add(new SelectListItem() { Text = assetType.Name, Value = assetType.Id.ToString() });


            List<NHCM.Domain.Entities.Status> statuses = new List<NHCM.Domain.Entities.Status>();
            statuses = await Mediator.Send(new GetStatusQuery() { category = "HL" });
            foreach (NHCM.Domain.Entities.Status status in statuses)
                ListOfStatus.Add(new SelectListItem() { Text = status.Dari, Value = status.Id.ToString() });



            List<ReferenceType> referenceTypes = new List<ReferenceType>();
            referenceTypes = await Mediator.Send(new GetReferenceTypeQuery() { ID = null });
            foreach (ReferenceType refe in referenceTypes)
                ListOfReferenceType.Add(new SelectListItem() { Text = refe.Name, Value = refe.Id.ToString() });


            List<PublicationType> publicationTypes = new List<PublicationType>();
            publicationTypes = await Mediator.Send(new GetPublicationTypeQuery() { ID = null });
            foreach (PublicationType publicationType in publicationTypes)
                ListOfPublicationType.Add(new SelectListItem() { Text = publicationType.Dari, Value = publicationType.Id.ToString() });

            await next.Invoke();
        }







      
    }
}
