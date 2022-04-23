using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalenyaTest.InPut;
using TalenyaTest.Processing;

namespace TalenyaTest
{
    class Program
    {
        static void Main(string[] args) {
            Input input;
            Processor proccesor;

            //In case you want to type the path as a variable
            //input = new JobDataLocalVarInput(@"",@"");

            //In case you want to type the path to the console
            input = new JobDataUserInput();

            proccesor = new JobDataProcessor(input);

            proccesor.writeOutputToFile();
        }
    } }

  


