using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        private readonly string _conn;
        public ContextFactory(IConfiguration configuration)
        {
            _conn = configuration["DATABASE_CONNECTION"];
        }
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseNpgsql(_conn);
            return new MyContext(optionsBuilder.Options);

        }
    }
}