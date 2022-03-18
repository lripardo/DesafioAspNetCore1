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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTruckContext _context;

        public DeleteModel(RazorPagesTruckContext context)
        {
            _context = context;
        }

        [BindProperty] public Truck Truck { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck = await _context.Truck.FindAsync(id);

            if (Truck != null)
            {
                _context.Truck.Remove(Truck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}