﻿using Booking.Models.Converters;
using Booking.Models.Converters.Interfaces;
using Booking.Repositories;
using Booking.Repositories.Interfaces;
using Booking.Services;
using Booking.Services.Interfaces;
using BookingApp.Data;
using BookingApp.Installers.Interfaces;
using BookingApp.Services;
using BookingApp.Services.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddTransient<IPlaceService, PlaceService>();

            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddSingleton<IPlaceConverter, PlaceConverter>();

            services.AddTransient<ISeatService, SeatService>();

            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddSingleton<ISeatConverter, SeatConverter>();

            services.AddSingleton<ISectorPriceConverter, SectorPriceConverter>();

            services.AddTransient<ITicketService, TicketService>();

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddSingleton<ITicketConverter, TicketConverter>();

            services.AddTransient<IEventTypeService, EventTypeService>();

            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddSingleton<IEventTypeConverter, EventTypeConverter>();

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        }
    }
}
