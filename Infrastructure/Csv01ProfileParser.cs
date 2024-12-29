using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;

public class Csv01ProfileParser
{
    public static void CsvParseToFolder(string fileVcfPath, string outputDir)
    {
        try
        {
            List<ProfileCsv1> vCards = ParseCsvFile(fileVcfPath);

            string json = JsonSerializer.Serialize(vCards);

            File.WriteAllText(Path.Combine(outputDir, DateTime.Now.ToString("yyMMddHHmmss") + ".json"), json);

            Console.WriteLine("Json saved to - " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public class ProfileCsv1Map : ClassMap<ProfileCsv1>
    {
        public ProfileCsv1Map()
        {
            Map(m => m.AdditionalName).Name("Additional Name");
            Map(m => m.AdditionalNameYomi).Name("Additional Name Yomi");
            Map(m => m.Address1City).Name("Address 1 - City");
            Map(m => m.Address1Country).Name("Address 1 - Country");
            Map(m => m.Address1ExtendedAddress).Name("Address 1 - Extended Address");
            Map(m => m.Address1Formatted).Name("Address 1 - Formatted");
            Map(m => m.Address1POBox).Name("Address 1 - PO Box");
            Map(m => m.Address1PostalCode).Name("Address 1 - Postal Code");
            Map(m => m.Address1Region).Name("Address 1 - Region");
            Map(m => m.Address1Street).Name("Address 1 - Street");
            Map(m => m.Address1Type).Name("Address 1 - Type");
            Map(m => m.BillingInformation).Name("Billing Information");
            Map(m => m.Birthday).Name("Birthday");
            Map(m => m.DirectoryServer).Name("Directory Server");
            Map(m => m.Email1Type).Name("E-mail 1 - Type");
            Map(m => m.Email1Value).Name("E-mail 1 - Value");
            Map(m => m.Email2Type).Name("E-mail 2 - Type");
            Map(m => m.Email2Value).Name("E-mail 2 - Value");
            Map(m => m.Email3Type).Name("E-mail 3 - Type");
            Map(m => m.Email3Value).Name("E-mail 3 - Value");
            Map(m => m.FamilyName).Name("Family Name");
            Map(m => m.FamilyNameYomi).Name("Family Name Yomi");
            Map(m => m.Gender).Name("Gender");
            Map(m => m.GivenName).Name("Given Name");
            Map(m => m.GivenNameYomi).Name("Given Name Yomi");
            Map(m => m.GroupMembership).Name("Group Membership");
            Map(m => m.Hobby).Name("Hobby");
            Map(m => m.IM1Service).Name("IM 1 - Service");
            Map(m => m.IM1Type).Name("IM 1 - Type");
            Map(m => m.IM1Value).Name("IM 1 - Value");
            Map(m => m.IM2Service).Name("IM 2 - Service");
            Map(m => m.IM2Type).Name("IM 2 - Type");
            Map(m => m.IM2Value).Name("IM 2 - Value");
            Map(m => m.Initials).Name("Initials");
            Map(m => m.Language).Name("Language");
            Map(m => m.Location).Name("Location");
            Map(m => m.MaidenName).Name("Maiden Name");
            Map(m => m.Mileage).Name("Mileage");
            Map(m => m.Name).Name("Name");
            Map(m => m.NamePrefix).Name("Name Prefix");
            Map(m => m.NameSuffix).Name("Name Suffix");
            Map(m => m.Nickname).Name("Nickname");
            Map(m => m.Notes).Name("Notes");
            Map(m => m.Occupation).Name("Occupation");
            Map(m => m.Organization1Department).Name("Organization 1 - Department");
            Map(m => m.Organization1JobDescription).Name("Organization 1 - Job Description");
            Map(m => m.Organization1Location).Name("Organization 1 - Location");
            Map(m => m.Organization1Name).Name("Organization 1 - Name");
            Map(m => m.Organization1Symbol).Name("Organization 1 - Symbol");
            Map(m => m.Organization1Title).Name("Organization 1 - Title");
            Map(m => m.Organization1Type).Name("Organization 1 - Type");
            Map(m => m.Organization1YomiName).Name("Organization 1 - Yomi Name");
            Map(m => m.Phone1Type).Name("Phone 1 - Type");
            Map(m => m.Phone1Value).Name("Phone 1 - Value");
            Map(m => m.Phone2Type).Name("Phone 2 - Type");
            Map(m => m.Phone2Value).Name("Phone 2 - Value");
            Map(m => m.Phone3Type).Name("Phone 3 - Type");
            Map(m => m.Phone3Value).Name("Phone 3 - Value");
            Map(m => m.Photo).Name("Photo");
            Map(m => m.Priority).Name("Priority");
            Map(m => m.Sensitivity).Name("Sensitivity");
            Map(m => m.ShortName).Name("Short Name");
            Map(m => m.Subject).Name("Subject");
            Map(m => m.Website1Type).Name("Website 1 - Type");
            Map(m => m.Website1Value).Name("Website 1 - Value");
            Map(m => m.Website2Type).Name("Website 2 - Type");
            Map(m => m.Website2Value).Name("Website 2 - Value");
            Map(m => m.YomiName).Name("Yomi Name");
        }
    }

    public static IEnumerable<ProfileCsv1> ParseCsv(string fileName, string csvString)
    {
        try
        {
            //var reader = new StringReader(csvString);
            //
            //var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

            using (var reader = new StringReader(csvString))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // The first row contains the header
                Delimiter = ",",       // Comma delimiter (default for CSV)
                TrimOptions = TrimOptions.Trim,
                HeaderValidated = null, // Skip header validation
                                        // MissingFieldFound = null 
            }))
            {
                csv.Context.RegisterClassMap<ProfileCsv1Map>();

                var records = csv.GetRecords<ProfileCsv1>().ToArray();

                return records;
            }

        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }

    public static List<ProfileCsv1> ParseCsvFile(string filePath)
    {
        //using (var reader = new StreamReader(filePath))
        //using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        //{
        //    HasHeaderRecord = true,  // Indicates that the first line is a header
        //}))
        //{
        //    var records = csv.GetRecords<ProfileCsv1>();
        //    return records.ToList();
        //}

        //using (var reader = new StreamReader(filePath))
        //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //{
        //    csv.Configuration.HasHeaderRecord = true;
        //    return csv.GetRecords<ProfileCsv1>().ToList();
        //}

        var contacts = new List<ProfileCsv1>();

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var records = csv.GetRecords<dynamic>().ToList();

            var TEST = records.Count;

            foreach (var record in records)
            {
                var profile = new ProfileCsv1();

                foreach (var property in record)
                {
                    var propertyName = property.Key;
                    var value = property.Value?.ToString();

                    // Use reflection to set properties dynamically
                    //var propInfo = typeof(ProfileCsv1).GetProperty(propertyName, (BindingFlags)StringComparison.OrdinalIgnoreCase);

                    var propInfo = typeof(ProfileCsv1).GetProperties().FirstOrDefault(p =>
                            string.Equals(p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName, propertyName, StringComparison.OrdinalIgnoreCase));

                    if (propInfo != null && value != null)
                    {
                        // Handle special cases like date parsing
                        // if (propInfo.PropertyType == typeof(DateTime?) && DateTime.TryParse(value, out var dateValue))
                        // {
                        //     propInfo.SetValue(contact, dateValue);
                        // }
                        // else
                        {
                            propInfo.SetValue(profile, value);
                        }
                    }
                }
                contacts.Add(profile);
            }
        }

        return contacts;
    }
}
