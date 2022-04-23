using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalenyaTest.InPut
{
    public class JobDataLocalVarInput:Input{
        public string txtFile { get; }

        public string txtFileName { get; }

        public string jsonFile { get; }

        public string jsonFileName { get; }

        //The constructor gets a text file path and a json file path and using the methods of the class to check the extension,read the file
        //and updates the properties of the class
        //In case of an invalid file ,the class methods will write the error to the console and exit the program
        public JobDataLocalVarInput(string txtFilePath,string jsonFilePath){
            txtFile=readTxtFile(txtFilePath);
            txtFileName = Path.GetFileName(txtFilePath);

            jsonFile =readJsonFile(jsonFilePath);
            jsonFileName = Path.GetFileName(jsonFilePath);

        }

        private static string readTxtFile(string path)
        {
            string StrResult = null;
                try
                { 
                    UserInputReader.checkExtension(path, ".txt");
                    StrResult = File.ReadAllText(path);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            return StrResult;
        }

        private static string readJsonFile(string path)
        {
            string StrResult = null;
            try
            {
                UserInputReader.checkExtension(path, ".json");
                StrResult = File.ReadAllText(path);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            return StrResult;
        }
    }
}
