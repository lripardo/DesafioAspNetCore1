#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioAspNetCore1.Models;

namespace DesafioAspNetCore1.Pages.Trucks
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTruckContext _context;

        public EditModel(RazorPagesTruckContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Truck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(Truck.ID))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool TruckExists(int id)
        {
            return _context.Truck.Any(e => e.ID == id);
        }
    }
}