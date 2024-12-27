using System.Drawing;
using System.Text;
using System.Web;

public static class Vcf01ProfileParser
{
    //public static void TestVcfParsing(string vcfFilePath, string imagesSavePath)
    //{
    //    try
    //    {
    //        var vCards = ParseVcfFile(vcfFilePath, imagesSavePath);
    //        string json = JsonSerializer.Serialize(vCards);
    //        File.WriteAllText(Path.Combine(imagesSavePath, DateTime.Now.ToString("yyMMddHHmmss") + ".json"), json);
    //        Console.WriteLine("Json saved to - " + imagesSavePath);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }
    //}

    public static List<Csv01Profile> ParseVcfFile(string vcfFilePath, string imagesSavePath)
    {
        var vCards = new List<Csv01Profile>();

        try
        {
            if (File.Exists(vcfFilePath))
            {
                var fileUploadedName = Path.GetFileName(vcfFilePath);

                using (var fileStream = File.OpenRead(vcfFilePath))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    Csv01Profile vCard = null;
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // TODO:
                        // check valid begin and end of Cards !!!

                        // Tested for - VERSION:2.1

                        if (line.StartsWith("BEGIN:VCARD"))
                        {
                            vCard = new Csv01Profile();
                        }
                        else if (line.StartsWith("END:VCARD"))
                        {
                            vCard.Created = DateTime.Now;
                            vCard.FileUploaded = fileUploadedName;
                            vCards.Add(vCard);
                        }
                        else if (line.StartsWith("N:")) vCard.Name += "," + line.Substring("N:".Length).TrimStart(',');
                        else if (line.StartsWith("FN:")) vCard.FullName += "," + line.Substring("FN:".Length).TrimStart(',');
                        else if (line.StartsWith("CATEGORIES:")) vCard.Categories += "," + line.Substring("CATEGORIES:".Length).TrimStart(',');
                        else if (line.StartsWith("TEL;CELL:")) vCard.Phone1Value += "," + line.Substring("TEL;CELL:".Length).TrimStart(',');
                        else if (line.StartsWith("TEL;TYPE=CELL:")) vCard.Phone2Value += "," + line.Substring("TEL;TYPE=CELL:".Length).TrimStart(',');
                        else if (line.StartsWith("VERSION:")) vCard.Version += "," + line.Substring("VERSION:".Length).TrimStart(',');
                        else if (line.StartsWith("X-GROUP:")) vCard.Group += "," + line.Substring("X-GROUP:".Length).TrimStart(',');
                        else if (line.StartsWith("N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:"))
                        {
                            vCard.Name += line.Substring("N;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:".Length).TrimStart(',').TrimEnd();
                            while (vCard.Name.EndsWith("="))
                                vCard.Name += streamReader.ReadLine();

                            vCard.Name = HttpUtility.UrlDecode(vCard.Name.Replace("==", "=").Replace("=", "%"));
                        }
                        else if (line.StartsWith("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:"))
                        {
                            vCard.FullName += line.Substring("FN;CHARSET=UTF-8;ENCODING=QUOTED-PRINTABLE:".Length).TrimStart(',').TrimEnd();
                            while (vCard.FullName.EndsWith("="))
                                vCard.FullName += streamReader.ReadLine();

                            vCard.FullName = HttpUtility.UrlDecode(vCard.FullName.Replace("==", "=").Replace("=", "%"));
                        }
                        else if (line.StartsWith("PHOTO;ENCODING=BASE64;JPEG:") || line.StartsWith("NOTE:Photo:"))
                        {
                            int prefixColonIndex = line.IndexOf(':');
                            if (prefixColonIndex == -1) { throw new Exception("ERROR parsing Photo string!"); }

                            string base64image = line.Substring(prefixColonIndex + 1);
                            while (!string.IsNullOrWhiteSpace(line = streamReader.ReadLine())) base64image += line;

                            try
                            {
                                byte[] imageBytes = Convert.FromBase64String(base64image);
                                string guidImageName = Guid.NewGuid() + ".jpg";

                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    using (Image image = Image.FromStream(ms))
                                    {
                                        image.Save(Path.Combine(imagesSavePath, guidImageName));

                                        vCard.PhotoFileName = guidImageName + ";"; // MULTI-Images !
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                vCard.PhotoFileName = "ERROR!";
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                            Console.WriteLine($"ERROR! SKIPPED! - {line}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR !!! - ", e.Message);
            throw new Exception();
        }

        return vCards;
    }
}
