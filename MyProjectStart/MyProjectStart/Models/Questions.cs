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
        public int id_rightanswer { get; set; }
    }
}
