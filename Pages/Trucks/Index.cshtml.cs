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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTruckContext _context;

        public IndexModel(RazorPagesTruckContext context)
        {
            _context = context;
        }

        public IList<Truck> Truck { get;set; }

        public async Task OnGetAsync()
        {
            Truck = await _context.Truck.ToListAsync();
        }
    }
}
