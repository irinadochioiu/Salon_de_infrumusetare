using Microsoft.AspNetCore.Mvc.RazorPages;
using Salon_de_infrumusetare.Data;

namespace Salon_de_infrumusetare.Models
{
    public class ServiciuCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Salon_de_infrumusetareContext context,
        serviciu Serviciu)
        {
            var allCategories = context.Category;
            var serviciuCategories = new HashSet<int>(
            Serviciu.ServiciuCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = serviciuCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateServiciuCategories(Salon_de_infrumusetareContext context,
        string[] selectedCategories, serviciu ServiciuToUpdate)
        {
            if (selectedCategories == null)
            {
                ServiciuToUpdate.ServiciuCategories = new List<ServiciuCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var ServiciuCategories = new HashSet<int>
            (ServiciuToUpdate.ServiciuCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!ServiciuCategories.Contains(cat.ID))
                    {
                        ServiciuToUpdate.ServiciuCategories.Add(
                        new ServiciuCategory
                        {
                            ServiciuID = ServiciuToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (ServiciuCategories.Contains(cat.ID))
                    {
                        ServiciuCategory courseToRemove
                        = ServiciuToUpdate
                        .ServiciuCategories
                       .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
