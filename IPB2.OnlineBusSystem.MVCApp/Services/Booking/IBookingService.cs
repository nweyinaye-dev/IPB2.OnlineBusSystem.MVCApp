using IPB2.OnlineBusSystem.MVCApp.Common;
using IPB2.OnlineBusSystem.MVCApp.Models;

namespace IPB2.OnlineBusSystem.MVCApp.Services.Booking
{
    public interface IBookingService
    {
        Task<ServiceResponse> CreateAsync(BookRequest request);
        Task<SearchBusResponse> SearchBus(SearchBusRequest request);
        Task<BookingDetailResponse> GetBookingDetailByUserAsync(string username, string phoneno);
        Task<BookingDetailResponse> GetBookingDetailAsync(string? search);
        Task<ServiceResponse> CancelAsync(string bookingId);
    }
}