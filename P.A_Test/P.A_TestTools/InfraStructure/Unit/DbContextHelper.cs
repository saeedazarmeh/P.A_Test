﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_TestTools.InfraStructure.Unit
{
    public static class DbContextHelper
    {
        public static void Save<TDbContext, TEntity>(
       this TDbContext dbContext,
       TEntity entity)
       where TDbContext : DbContext
       where TEntity : class
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }
    }
}
