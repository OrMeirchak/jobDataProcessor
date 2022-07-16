using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalenyaTest.OutPut
{
    [Serializable]
    class OutputJobData {

         [JsonProperty("filename")]
        public string fileName { get; set; }

        [JsonProperty("jobTitle")]
        public string jobTitle { get; set; }

        [JsonProperty("Skills")]
        List<Skill> skills { get; set; }

        class Skill: IComparable
        {

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("count")]
            public int count { get; set; }

            public int CompareTo(object obj){
                if (obj == null) return 1;

                Skill otherSkill = obj as Skill;
                if (otherSkill != null)
                    return otherSkill.count.CompareTo(this.count);
                else
                    throw new ArgumentException("Object is not a skill");
            }
        }

        public OutputJobData(){
            skills = new List<Skill>();
        }

        public void addSkill(string name, int count){
            Skill skill = new Skill();
            skill.name = name;
            skill.count = count;

            skills.Add(skill);
        }

        public void sortSkillsList(){
            skills.Sort();
        }
    }
}
