using System.IO.Compression;
using Infrastructure;
using Microsoft.VisualBasic.FileIO; // To Send to Recycle Bin.

namespace Utilities
{
    public class FileWorker
    {
        string blablatest = "";

        bool isDbFileExists(string dbFile)
        {
            return File.Exists(dbFile) && new FileInfo(dbFile).Length > 0;
        }

        bool SkipAction(bool isStart)
        {
            bool isWrong;
            Console.WriteLine(isStart ? "Write To Start Work?" : "Write To Finish?");

            blablatest = Console.ReadLine();

            if (isStart)
            {
                isWrong = string.IsNullOrEmpty(blablatest) || blablatest.Length < 12;
            }
            else
            {
                Console.WriteLine("Write again:");
                isWrong = string.IsNullOrEmpty(blablatest) || blablatest != Console.ReadLine();
            }

            if (isWrong)
                Console.WriteLine("\r\nWRONG Abrakadabra!");

            return isWrong;
        }

        internal void CreateDatabase() // string mainPath)
        {
            var dtbaseFile = Constants.dtbaseFile;
            var lockedfile = Constants.lockedFile;
            var packedFile = Constants.packedFile;
            var workFolder = Constants.workFolder;
            try
            {
                if (isDbFileExists(dtbaseFile))
                {
                    if (!SkipAction(false))
                    {
                        string lockedFileBkp = $"{lockedfile}.B4.{DateTime.Now:ddHHmmss}";

                        if (File.Exists(lockedfile))
                            File.Copy(lockedfile, lockedFileBkp, true);

                        if (File.Exists(lockedFileBkp))
                        {
                            FileSystem.DeleteFile(lockedfile, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            ZipFile.CreateFromDirectory(workFolder, packedFile, CompressionLevel.SmallestSize, true);
                        }

                        if (File.Exists(packedFile))
                            DbCreator.EncryptByPass(packedFile, lockedfile, blablatest);

                        if (File.Exists(lockedfile))
                        {
                            Directory.Delete(workFolder, true);
                            File.Delete(packedFile);
                        }
                        Console.WriteLine("\r\n Successfully Finished.");
                    }
                }
                else if (!Directory.Exists(workFolder) && !isDbFileExists(dtbaseFile))
                {
                    if (!SkipAction(true))
                    {
                        DbCreator.DecryptByPass(lockedfile, packedFile, blablatest);

                        if (File.Exists(packedFile))
                            ZipFile.ExtractToDirectory(packedFile, Constants.aWorkDir);

                        if (isDbFileExists(dtbaseFile))
                            File.Delete(packedFile);

                        Console.WriteLine("\r\n Successfully Prepaired For Work.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
