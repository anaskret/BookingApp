﻿using Booking.Models.Converters;
using Booking.Models.Converters.Interfaces;
using Booking.Services;
using Booking.Services.Interfaces;
using BookingApp.Data;
using BookingApp.Installers.Interfaces;
using BookingApp.Services;
using BookingApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            services.AddTransient<IEventService, EventService>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddSingleton<IEventConverter, EventConverter>();
        }
    }
}
