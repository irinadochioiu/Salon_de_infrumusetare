#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Salon_de_infrumusetare.Data;
using Salon_de_infrumusetare.Models;
using Salon_de_infrumusetare.Models;
namespace Salon_de_infrumusetare.Pages.Servicii
{
    public class CreateModel : ServiciuCategoriesPageModel
    {
        private readonly Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext _context;

        public CreateModel(Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var serviciu = new serviciu();
            serviciu.ServiciuCategories = new List<ServiciuCategory>();
            PopulateAssignedCategoryData(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public serviciu serviciu { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newserviciu = new serviciu();
            if (selectedCategories != null)
            {
                newserviciu.ServiciuCategories = new List<ServiciuCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ServiciuCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newserviciu.ServiciuCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<serviciu>(
 newserviciu,
 "Serviciu",
 i => i.Tip_serviciu, i => i.Personalul,
 i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.serviciu.Add(newserviciu);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newserviciu);
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.serviciu.Add(serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
