using System;
using System.Collections.Generic;
using System.Text;
using MyProjectStart.Services;
using Xamarin.Essentials;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Firebase.Database;
using System.Linq;
using System.Collections.ObjectModel;

namespace MyProjectStart.Models
{
   public class TestsModel
    {


        public int TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string LearningUrl { get; set; }
        public int CategoryId { get; set; }
        
    
      
            


    }
}
