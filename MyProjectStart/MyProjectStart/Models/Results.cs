using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectStart.Models
{
    public class Results
    {
        public int id_result { get; set; }
        public string NameTestDone { get; set; }
        public string User_login { get; set; }
        public int CathegoryId { get; set; }
        public int TemaId { get; set; }

        public double Scoreprecennt { get; set; }
    }
}
