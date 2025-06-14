using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PositionMgmt.Application.IServices;
using PositionMgmt.Application.Services;
using PositionMgmt.Domain.IRepository;
using PositionMgmt.Infrastructure.Models;
using PositionMgmt.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMgmt.Domain
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PositionMgmtDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PositionMgmtDBContext"));
            });


            //Repositories
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            //Services
            services.AddScoped<IMasterServices, MasterServices>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
