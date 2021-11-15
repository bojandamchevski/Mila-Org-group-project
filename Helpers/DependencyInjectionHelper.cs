using DataAccess;
using DataAccess.Implementations;
using DataAccess.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(x =>
                x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IPersonRepository<Admin>, AdminRepository>();
            services.AddScoped<IPersonRepository<User>, UserRepository>();
            services.AddScoped<IPersonRepository<Trainer>, TrainerRepository>();
            services.AddScoped<IRepository<Blog>, BlogRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Chapter>, ChapterRepository>();
            services.AddScoped<IRepository<Contact>, ContactRepository>();
            services.AddScoped<IRepository<Research>, ResearchRepository>();
            services.AddScoped<IRepository<Training>, TrainingRepository>();
            services.AddScoped<IRepository<UserTraining>, UserTrainingRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IResearchService, ResearchService>();
            services.AddScoped<ITrainingService, TrainingService>();
        }
    }
}
