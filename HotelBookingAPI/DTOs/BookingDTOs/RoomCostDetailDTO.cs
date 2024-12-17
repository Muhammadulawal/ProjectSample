namespace HotelBookingAPI.DTOs.BookingDTOs;

public class RoomCostDetailDTO
{
    public int RoomID { get; set; }
    public string RoomNumber { get; set; }
    public decimal RoomPrice { get; set; }       // Cost for individual room
    public int NumberOfNights { get; set; }
    public decimal TotalPrice { get; set; }       // Cost for individual room multiplied by Number of Nights
}