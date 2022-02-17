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
    public class IndexModel : PageModel
    {
        private readonly Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext _context;

        public IndexModel(Salon_de_infrumusetare.Data.Salon_de_infrumusetareContext context)
        {
            _context = context;
        }
        public IList<serviciu> serviciu { get; set; }
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ServiciuD = new ServiciuData();

            ServiciuD.serviciu = await _context.serviciu
                .Include(b => b.Publisher)
 .Include(b => b.ServiciuCategories)
 .ThenInclude(b => b.Category)
 .AsNoTracking()
 .OrderBy(b => b.Tip_serviciu)
 .ToListAsync();
            if (id != null)
            {
                ServiciuID = id.Value;
                serviciu serviciu = ServiciuD.serviciu
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Categories = serviciu.ServiciuCategories.Select(s => s.Category);
            }
        }
    }
}