using AutoMapper;

public class ProfileParser
{
    private readonly IMapper _mapper;

    public ProfileParser(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<FullProfile>> ParseUploadedProfileAsync(string contentType, string fileName, string fileContent)
    {
        if (contentType == "text/csv" && Path.GetExtension(fileName) == ".csv" && fileContent.Length > 3)
        {
            IEnumerable<ProfileCsv1> csv1Profiles = Csv01ProfileParser.ParseCsv(fileName, fileContent);
            
            IEnumerable<FullProfile> dbProfiles = _mapper.Map<IEnumerable<FullProfile>>(csv1Profiles);

            return dbProfiles;
        }
        else
        {
            throw new NotImplementedException();
        }

        //switch (profileType)
        //{
        //    case ProfilesTypes.Csv01:
        //        newProfiles = Csv01ProfileParser.ParseCsv(fileNameOnServer);
        //        break;
        //    case ProfilesTypes.Csv02:
        //        throw new NotImplementedException();
        //    case ProfilesTypes.Vcf01:
        //        throw new NotImplementedException();
        //    case ProfilesTypes.Vcf02:
        //        throw new NotImplementedException();
        //    default:
        //        throw new NotImplementedException();
        //}
    }
}
