using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalenyaTest.InPut
{
    class JobDataUserInput:Input{

        public string txtFile { get; }
        public string txtFileName { get; }
        public string jsonFile { get; }
        public string jsonFileName { get; }

        //The constructor asks the user to type input and uses a UserInputReader to get the files from the user
        public JobDataUserInput()
        {
            Console.WriteLine("Please type the full path of the text file");
            UserInputReader txtFileReader = new UserInputReader(".txt");
            txtFileName = txtFileReader.fileName;
            txtFile = txtFileReader.file;

            Console.WriteLine("Please type the full path of the json file");
            UserInputReader jsonFileReader = new UserInputReader(".json");
            jsonFileName = jsonFileReader.fileName;
            jsonFile = jsonFileReader.file;
        }
    }
}
