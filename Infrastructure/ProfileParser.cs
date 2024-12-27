public class ProfileParser
{
    const string outputFolder = "";

    public async Task<string> ParseUploadedProfileAsync(string fileNameOnServer, ProfilesTypes profileType)
    {
        switch (profileType)
        {
            case ProfilesTypes.Csv01:
                List<Csv01Profile> newProfiles = Csv01ProfileParser.ParseCsv(fileNameOnServer);

                // TODO:
                // SAVE TO DB !!!!!!!!!!
                // SAVE TO DB !!!!!!!!!!



                break;
            case ProfilesTypes.Csv02:
                break;
            case ProfilesTypes.Vcf01:
                break;
            case ProfilesTypes.Vcf02:
                break;
            default:
                break;
        }

        throw new NotImplementedException();
    }
}
