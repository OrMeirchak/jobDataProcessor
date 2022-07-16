using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TalenyaTest.InPut;
using TalenyaTest.OutPut;

namespace TalenyaTest.Processing
{
    class JobDataProcessor : Processor
    {
       private OutputJobData output=new OutputJobData();
        public string outputJsonFile { get; }

        //The constructor get input's instance and parse it to json format as required in the task
        public JobDataProcessor(Input input){
            output.fileName = input.txtFileName;
            try {
                txtFileProcessor(jsonFileProcessor(input.jsonFile), input.txtFile);
                outputJsonFile = JsonConvert.SerializeObject(output);
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            
        }

        //The function writes the output to a new .json file. The file name is 'out'
        //In case A file named 'out' already exists,the file name will be 'out2','out3',....
        //The function write to console the full path of the new file.
        public void writeOutputToFile(){
            string outputFileName = "out";

            int count = 1;
            while (File.Exists(Directory.GetCurrentDirectory() + @"\" + outputFileName)){
                count++;
                outputFileName = "out" + count.ToString();
            }
            File.WriteAllText(outputFileName, outputJsonFile);
            Console.WriteLine("Updated json file location : "+ Directory.GetCurrentDirectory()+@"\"+ outputFileName);
        }

        //The function get a list of strings and text file
        //The function counts how many times each string appears in the text file
        //and updates and sorts the skills list in the output variable
        private void txtFileProcessor(List<string> skills, string txtFile){
            foreach (string skill in skills) {
                output.addSkill(skill, Regex.Matches(txtFile, skill).Count);
            }
            output.sortSkillsList();
        }

        //This function get a json File and by using dynamic type objects it finds the 'Skills list' and the 'PositionTitle'.
        //In case the file in a format that the function did not expect to get.The function throw 'InvalidJsonSchemaException'
        private List<string> jsonFileProcessor(string jsonFile)
        {
            List<string> skills = new List<string>();
            try {
                dynamic input = JsonConvert.DeserializeObject(jsonFile);

                dynamic firstObject = input.result[0]._value;
                bool positionTitleFound = false;
                bool competencyFound = false;
                dynamic compentencyValue = null;
                int i = 0;
                while ((firstObject[i] != firstObject.Last)
                    && ((competencyFound is false) || (positionTitleFound is false)))
                {
                    if (string.Equals(Convert.ToString(firstObject[i]._name), "PositionTitle") == true)
                    {
                        output.jobTitle = Convert.ToString(firstObject[i]._value);
                        positionTitleFound = true;
                    }
                    else if (string.Equals(Convert.ToString(firstObject[i]._name), "Competency") == true)
                    {
                        compentencyValue = firstObject[i]._value;
                        competencyFound = true;
                    }
                    i++;
                }

                if (positionTitleFound is false)
                {
                    throw new InvalidJsonSchemaException();
                }

                int j = 0;
                while (compentencyValue[j] != compentencyValue.Last)
                {
                    dynamic pointer = compentencyValue[j];
                    int k = 0;
                    while ((pointer[k] != pointer.Last) && (string.Equals(Convert.ToString(pointer[k]._name), "skillName")) == false)
                    {
                        k++;
                    }
                    j++;
                    skills.Add(Convert.ToString(pointer[k]._value));
                }
            }catch(Exception e) {
                if ((e is JsonReaderException)||(e is Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)){
                    throw new InvalidJsonSchemaException();
                }
                else{
                    throw e;
                }
            }
            return skills;
        }
    }
}

