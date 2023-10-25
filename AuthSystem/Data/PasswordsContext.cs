using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Data
{
    public class PasswordsContext : DbContext
    {
        public PasswordsContext (DbContextOptions<PasswordsContext> options)
            : base(options)
        {
        }

        public DbSet<AuthSystem.Models.Passwords> Passwords { get; set; } = default!;
    }
}
