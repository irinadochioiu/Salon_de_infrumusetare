#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_de_infrumusetare.Data;
using Salon_de_infrumusetare.Models;

namespace Salon_de_infrumusetare.Pages.Servicii
{
    public class DetailsModel : PageModel
    {
        private readonly Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext _context;

        public DetailsModel(Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext context)
        {
            _context = context;
        }

        public serviciu serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            serviciu = await _context.serviciu.FirstOrDefaultAsync(m => m.ID == id);

            if (serviciu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
