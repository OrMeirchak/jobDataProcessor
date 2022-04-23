using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalenyaTest.InPut
{
     interface Input {
        string txtFile { get; }//The contents of the text file
        string txtFileName { get; }
        string jsonFile { get; }//The contents of the json file
        string jsonFileName { get; }
    }
}
