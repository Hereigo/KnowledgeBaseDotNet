using AutoMapper;

public class ProfileParser
{
    private readonly IMapper _mapper;

    public ProfileParser(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<AProfile>> ParseUploadedProfileAsync(string contentType, string fileName, string fileContent)
    {
        IEnumerable<AProfile> dbProfiles;

        if (contentType == "text/csv" && Path.GetExtension(fileName) == ".csv" && fileContent.Length > 3)
        {
            IEnumerable<ProfileCsv1> csv1Profiles = Csv01ProfileParser.ParseCsv(fileName, fileContent);
            dbProfiles = _mapper.Map<IEnumerable<AProfile>>(csv1Profiles);
        }
        else if (contentType == "text/vcf" && Path.GetExtension(fileName) == ".vcf" && fileContent.Length > 3)
        {
            dbProfiles = Vcf01ProfileParser.ParseVcfFile(fileName, fileContent);
        }
        else
        {
            throw new NotImplementedException();
        }

        return dbProfiles;

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
