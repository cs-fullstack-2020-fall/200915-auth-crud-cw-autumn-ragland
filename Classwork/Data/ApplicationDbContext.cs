using System;
using System.Collections.Generic;
using System.Text;
using Classwork.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Classwork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // add db set of type book model - new table in generated db file
        public DbSet<BookModel> books {get;set;}
    }
}
