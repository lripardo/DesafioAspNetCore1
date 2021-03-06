#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DesafioAspNetCore1.Models;

namespace DesafioAspNetCore1.Pages.Trucks
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTruckContext _context;

        public DetailsModel(RazorPagesTruckContext context)
        {
            _context = context;
        }

        public Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck = await _context.Truck.FirstOrDefaultAsync(m => m.ID == id);

            if (Truck == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
