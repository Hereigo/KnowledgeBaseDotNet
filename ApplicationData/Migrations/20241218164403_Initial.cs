using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Csv01Profiles",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalName = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: false),
                    YomiName = table.Column<string>(type: "TEXT", nullable: false),
                    GivenNameYomi = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalNameYomi = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyNameYomi = table.Column<string>(type: "TEXT", nullable: false),
                    NamePrefix = table.Column<string>(type: "TEXT", nullable: false),
                    NameSuffix = table.Column<string>(type: "TEXT", nullable: false),
                    Initials = table.Column<string>(type: "TEXT", nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    MaidenName = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    BillingInformation = table.Column<string>(type: "TEXT", nullable: false),
                    DirectoryServer = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<string>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: false),
                    Hobby = table.Column<string>(type: "TEXT", nullable: false),
                    Sensitivity = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false),
                    GroupMembership = table.Column<string>(type: "TEXT", nullable: false),
                    Email1Type = table.Column<string>(type: "TEXT", nullable: false),
                    Email1Value = table.Column<string>(type: "TEXT", nullable: false),
                    Email2Type = table.Column<string>(type: "TEXT", nullable: false),
                    Email2Value = table.Column<string>(type: "TEXT", nullable: false),
                    Email3Type = table.Column<string>(type: "TEXT", nullable: false),
                    Email3Value = table.Column<string>(type: "TEXT", nullable: false),
                    IM1Type = table.Column<string>(type: "TEXT", nullable: false),
                    IM1Service = table.Column<string>(type: "TEXT", nullable: false),
                    IM1Value = table.Column<string>(type: "TEXT", nullable: false),
                    IM2Type = table.Column<string>(type: "TEXT", nullable: false),
                    IM2Service = table.Column<string>(type: "TEXT", nullable: false),
                    IM2Value = table.Column<string>(type: "TEXT", nullable: false),
                    Phone1Type = table.Column<string>(type: "TEXT", nullable: false),
                    Phone1Value = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2Type = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2Value = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3Type = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3Value = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Type = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Formatted = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Street = table.Column<string>(type: "TEXT", nullable: false),
                    Address1City = table.Column<string>(type: "TEXT", nullable: false),
                    Address1POBox = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Region = table.Column<string>(type: "TEXT", nullable: false),
                    Address1PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Country = table.Column<string>(type: "TEXT", nullable: false),
                    Address1ExtendedAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1Type = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1Name = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1YomiName = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1Title = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1Department = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    Organization1Location = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizationJobDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Website1Type = table.Column<string>(type: "TEXT", nullable: false),
                    Website1Value = table.Column<string>(type: "TEXT", nullable: false),
                    Website2Type = table.Column<string>(type: "TEXT", nullable: false),
                    Website2Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csv01Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vcf01Profiles",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Categories = table.Column<string>(type: "TEXT", nullable: false),
                    FileUploaded = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "TEXT", nullable: false),
                    PhotoFileName = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vcf01Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vcf02Profiles",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    ProfileID = table.Column<string>(type: "TEXT", nullable: false),
                    AaaType = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GivenName = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalName = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: false),
                    YomiName = table.Column<string>(type: "TEXT", nullable: false),
                    GivenNameYomi = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalNameYomi = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyNameYomi = table.Column<string>(type: "TEXT", nullable: false),
                    NamePrefix = table.Column<string>(type: "TEXT", nullable: false),
                    NameSuffix = table.Column<string>(type: "TEXT", nullable: false),
                    Initials = table.Column<string>(type: "TEXT", nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: false),
                    MaidenName = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    BillingInformation = table.Column<string>(type: "TEXT", nullable: false),
                    DirectoryServer = table.Column<string>(type: "TEXT", nullable: false),
                    Mileage = table.Column<string>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: false),
                    Hobby = table.Column<string>(type: "TEXT", nullable: false),
                    Sensitivity = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Photo = table.Column<string>(type: "TEXT", nullable: false),
                    GroupMembership = table.Column<string>(type: "TEXT", nullable: false),
                    Email1type = table.Column<string>(type: "TEXT", nullable: false),
                    Email1value = table.Column<string>(type: "TEXT", nullable: false),
                    Email2type = table.Column<string>(type: "TEXT", nullable: false),
                    Email2value = table.Column<string>(type: "TEXT", nullable: false),
                    Email3type = table.Column<string>(type: "TEXT", nullable: false),
                    Email3value = table.Column<string>(type: "TEXT", nullable: false),
                    IM1type = table.Column<string>(type: "TEXT", nullable: false),
                    IM1Service = table.Column<string>(type: "TEXT", nullable: false),
                    IM1value = table.Column<string>(type: "TEXT", nullable: false),
                    Phone1type = table.Column<string>(type: "TEXT", nullable: false),
                    Phone1value = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2type = table.Column<string>(type: "TEXT", nullable: false),
                    Phone2value = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3type = table.Column<string>(type: "TEXT", nullable: false),
                    Phone3value = table.Column<string>(type: "TEXT", nullable: false),
                    Address1type = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Formatted = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Street = table.Column<string>(type: "TEXT", nullable: false),
                    Address1City = table.Column<string>(type: "TEXT", nullable: false),
                    Address1POBox = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Region = table.Column<string>(type: "TEXT", nullable: false),
                    Address1PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Address1Country = table.Column<string>(type: "TEXT", nullable: false),
                    Address1ExtendedAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Org1type = table.Column<string>(type: "TEXT", nullable: false),
                    Org1Name = table.Column<string>(type: "TEXT", nullable: false),
                    Org1YomiName = table.Column<string>(type: "TEXT", nullable: false),
                    Org1Title = table.Column<string>(type: "TEXT", nullable: false),
                    Org1Department = table.Column<string>(type: "TEXT", nullable: false),
                    Org1Symbol = table.Column<string>(type: "TEXT", nullable: false),
                    Org1Location = table.Column<string>(type: "TEXT", nullable: false),
                    Org1JobDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Website1type = table.Column<string>(type: "TEXT", nullable: false),
                    Website1value = table.Column<string>(type: "TEXT", nullable: false),
                    Website2type = table.Column<string>(type: "TEXT", nullable: false),
                    Website2value = table.Column<string>(type: "TEXT", nullable: false),
                    Event1type = table.Column<string>(type: "TEXT", nullable: false),
                    Event1value = table.Column<string>(type: "TEXT", nullable: false),
                    CustomField1type = table.Column<string>(type: "TEXT", nullable: false),
                    CustomField1value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vcf02Profiles", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Csv01Profiles");

            migrationBuilder.DropTable(
                name: "Vcf01Profiles");

            migrationBuilder.DropTable(
                name: "Vcf02Profiles");
        }
    }
}
