using BookingApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Booking.Services.Interfaces;
using Booking.Models.Contracts.Requests.CreateRequests;
using Booking.Models.Models;
using Booking.Models.Contracts.Requests.GetRequests;
using DinkToPdf.Contracts;
using DinkToPdf;
using Booking.App.Utility;
using System.IO;

namespace Booking.App.Controllers
{
    public class TicketController: Controller
    {
        private readonly ITicketService _ticketService;
        private IConverter _converter;

        public TicketController(ITicketService ticketService, IConverter converter)
        {
            _ticketService = ticketService;
            _converter = converter;
        }

        [HttpGet(ApiRoutes.Tickets.Get)]
        public async Task<IActionResult> GetById([FromRoute] Guid ticketId)
        {
            GetTicketRequest ticket;
            try
            {
                ticket = await _ticketService.GetTicketById(ticketId);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PdfGenerator.GetHTMLString(ticket),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            return File(file, "api/pdf", "Ticket.pdf");
        }

        [HttpPost(ApiRoutes.Tickets.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTicketRequest createTicket)
        {
            Ticket created;
            try
            {
                 created = await _ticketService.CreateTicket(createTicket);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(created);
        }
    }
}
