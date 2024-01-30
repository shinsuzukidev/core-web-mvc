using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_app.Models;

namespace mvc_app.Data
{
    public class mvc_appContext : DbContext
    {
        public mvc_appContext (DbContextOptions<mvc_appContext> options)
            : base(options)
        {
        }

        public DbSet<mvc_app.Models.Movie> Movie { get; set; } = default!;
    }
}
