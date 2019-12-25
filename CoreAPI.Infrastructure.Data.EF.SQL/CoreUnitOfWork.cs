using System;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef;

namespace CoreAPI.Infrastructure.Data.EF.SQL
{
    public class CoreUnitOfWork:EfUnitOfWork
    {
        public CoreUnitOfWork(DbContextOptions options) : base(options)
        {
        }
    }
}
