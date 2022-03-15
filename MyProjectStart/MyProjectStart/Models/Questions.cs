using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectStart.Models
{
    public class Questions
    {
        public int id_quest { get; set; }
        public string TextQuest { get; set; }
        public int id_test { get; set; }
        public string quest_answer1 { get; set; }
        public string quest_answer2 { get; set; }
        public string quest_answer3 { get; set; }
        public string quest_answer4 { get; set; }
        public string quest_rightanswer { get; set; }
    }
}
