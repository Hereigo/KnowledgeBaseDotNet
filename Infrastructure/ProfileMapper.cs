namespace Infrastructure
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            CreateMap<ProfileCsv1, FullProfile>();
        }
    }
}
