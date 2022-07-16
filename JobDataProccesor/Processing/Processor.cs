using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalenyaTest.InPut;
using TalenyaTest.OutPut;

class InvalidJsonSchemaException : Exception{

    public override string Message { get; }

    public InvalidJsonSchemaException(){
        Message = "Invalid Json Schema";
    }
}

namespace TalenyaTest.Processing
{
    interface Processor{
        string outputJsonFile{ get; }
        void writeOutputToFile();
    }
}
