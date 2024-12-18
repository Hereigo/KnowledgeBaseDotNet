using System.Text.RegularExpressions;
using Utilities;

int yourSelect = 0;
string workDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "EOS", "Tests");
string workDirTemp = Path.Combine(workDir, "VCF_TEST");
string fileVcf = Path.Combine(workDirTemp, "20240813.vcf");
string fileCsv = Path.Combine(workDirTemp, "GmaExpo_contacts.csv");

while (yourSelect == 0)
{
    Console.WriteLine("Choose:" +
        "\r\n\r\n 1. Create Database." +
        "\r\n\r\n 2. VCF Parser1." +
        "\r\n\r\n 3. CSV Parser1." +
        "\r\n\r\n 9+. TEMP TEST.\r\n");

    int.TryParse(Console.ReadLine(), out yourSelect);
}

switch (yourSelect)
{
    case 1:
        var main = new FileWorker();
        main.CreateDatabase(workDir);
        break;
    case 2:
        VcfProfileParser.TestVcfParsing(fileVcf, workDirTemp);
        break;
    case 3:
        CsvProfileParser.TestCsvParsing(fileCsv, workDirTemp);
        break;
    default:
        // TEMP TESTING BLOCK ...
        string unicodeText = @"\u0421\u043E\u043D\u044F, \u0414\u0430\u0448\u0438\u043D\u0430";
        string TEST = Regex.Replace(unicodeText, @"\\u([0-9A-Fa-f]{4})", m => char.ConvertFromUtf32(int.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber)));
        File.WriteAllText(Path.Combine(workDirTemp, DateTime.Now.ToString("yyMMddHHmmss") + ".json"), TEST);
        break;
}

Console.WriteLine("\r\nFinished.\r\n\r\n in " + workDirTemp);
Console.ReadLine();