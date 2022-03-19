using Firebase.Database;
using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace MyProjectStart.Services
{
    public class ItemLearningService
    {
        FirebaseClient client;
        public ItemLearningService()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<ItemLearnCategory>> GetItemsLearningCategories()
        {
            var ListItemLearnCategory = (await client.Child("ItemLearnCategory").OnceAsync<ItemLearnCategory>()).Select(f => new ItemLearnCategory
            {
                id_itemLearn = f.Object.id_itemLearn,
                id_LearCathegory = f.Object.id_LearCathegory,
                ImageUrlItem = f.Object.ImageUrlItem,
                NameItemLearn = f.Object.NameItemLearn,
                Url_toLerningSite = f.Object.Url_toLerningSite

            }).ToList();
            return ListItemLearnCategory;
        }
        public async Task<ObservableCollection<ItemLearnCategory>> GetItemsLeanCategoriesAsunc(int learncategory)
        {
            var ItemsLearnCategory = new ObservableCollection<ItemLearnCategory>();
            var items = (await GetItemsLearningCategories()).Where(p => p.id_LearCathegory == learncategory).ToList();
            foreach (var item in items)
            {
                ItemsLearnCategory.Add(item);

            }
            return ItemsLearnCategory;
        }
    }
}
