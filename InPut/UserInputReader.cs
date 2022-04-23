using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalenyaTest.InPut
{

    //The class provides tools for handling and reading files from the user
    class UserInputReader
    {
        public string fileName { get;  }
        public string file { get;  }

        //The function gets file path from the user,read the file and updates the class properties
        public UserInputReader(string expectedExtension) {
            bool valid = false;
            while (valid is false)
            {
                try{
                    string path=Console.ReadLine();
                    file = File.ReadAllText(path);
                    fileName = Path.GetFileName(path);
                    valid = true;
                }
                catch (Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again\n");
                }
            }   
        }

        //The function gets file path and expected extension
        //In case the file extension is not the same as the expected extension the function throw 'ExtensionException'
        public static void checkExtension(string path,string extension) {
            FileInfo file = new FileInfo(path);

            if(string.Equals(file.Extension, extension)==false){
                throw new ExtensionException(extension);
            }
        }
    }
    class ExtensionException : Exception {

        public override string Message { get; }
        public ExtensionException(string expectedExtension) {
            Message = "Invalid file extension\nExected extension : " + expectedExtension;
        }
    }
}
