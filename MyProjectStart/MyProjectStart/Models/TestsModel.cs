using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjectStart.Models
{
   public class TestsModel
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int RightAnsverId { get; set; }
    }
}
