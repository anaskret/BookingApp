using Booking.Models.Converters;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories;
using Booking.Repositories.Interfaces;
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
                    configuration.GetConnectionString("DefaultConnectionLocal")));
            services.AddControllers();

            services.AddTransient<IEventService, EventService>();

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddSingleton<IEventConverter, EventConverter>();
            
            services.AddTransient<IPlaceService, PlaceService>();

            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddSingleton<IPlaceConverter, PlaceConverter>();
            
            services.AddTransient<ISeatService, SeatService>();

            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddSingleton<ISeatConverter, SeatConverter>();
        }
    }
}
