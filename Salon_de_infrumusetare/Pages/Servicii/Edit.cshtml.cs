
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Salon_de_infrumusetare.Data;
using Salon_de_infrumusetare.Models;

using Salon_de_infrumusetare.Models;

namespace Salon_de_infrumusetare.Pages.Servicii
{
    public class EditModel : ServiciuCategoriesPageModel
    {
        private readonly Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext _context;

        public EditModel(Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public serviciu serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            serviciu = await _context.serviciu
 .Include(b => b.Publisher)
 .Include(b => b.ServiciuCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (serviciu == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, serviciu);

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviciuToUpdate = await _context.serviciu
 .Include(i => i.Publisher)
 .Include(i => i.ServiciuCategories)
 .ThenInclude(i => i.Category)
 .FirstOrDefaultAsync(s => s.ID == id);
            if (serviciuToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Tip_serviciu, i => i.Personalul,
            i => i.Price, i => i.PublishingDate, i => i.Publisher))
            {
                UpdateServiciuCategories(_context, selectedCategories, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateServiciuCategories pentru a aplica informatiile din checkboxuri la entitatea Servicii care
            //este editata
            UpdateServiciuCategories(_context, selectedCategories, serviciuToUpdate);
            PopulateAssignedCategoryData(_context, serviciuToUpdate);
            return Page();
        }
    }
}

