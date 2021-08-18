using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotiUcse.Models;

    public class MvcNoticiasContext : DbContext
    {
        public MvcNoticiasContext (DbContextOptions<MvcNoticiasContext> options)
            : base(options)
        {
        }

        public DbSet<NotiUcse.Models.NoticiaModel> NoticiaModel { get; set; }
    }
