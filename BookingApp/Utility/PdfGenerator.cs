using Booking.Models.Contracts.Requests.GetRequests;
using System.Text;
namespace Booking.App.Utility
{
    public static class PdfGenerator
    {
        public static string GetHTMLString(GetTicketRequest ticket)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1 align='center'>Booking Confirmation</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Email</th>
                                        <th>BookingDate</th>
                                        <th>EventDate</th>
                                        <th>StatusId</th>
                                        <th>TicketId</th>
                                        <th>SeatCoordinates</th>
                                        <th>Price</th>
                                    </tr>");

            
            sb.AppendFormat(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                <td>{4}</td>
                                <td>{5}</td>
                                <td>{6}</td>
                                </tr>", ticket.Email,ticket.BookingDate,ticket.EventDate, ticket.StatusId,
                                ticket.TicketId, ticket.SeatCoordinates, ticket.Price);
            

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
