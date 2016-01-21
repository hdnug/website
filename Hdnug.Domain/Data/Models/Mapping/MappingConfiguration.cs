using System.Data.Entity;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class MappingConfiguration : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClaimMap());
            modelBuilder.Configurations.Add(new LoginMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new MemberMap());
            modelBuilder.Configurations.Add(new MeetingMap());
            modelBuilder.Configurations.Add(new SponsorMap());
            modelBuilder.Configurations.Add(new PrizeSponsorshipMap());
            modelBuilder.Configurations.Add(new SpeakerMap());
            modelBuilder.Configurations.Add(new PresentationMap());
            modelBuilder.Configurations.Add(new ImageMap());
        }
    }
}