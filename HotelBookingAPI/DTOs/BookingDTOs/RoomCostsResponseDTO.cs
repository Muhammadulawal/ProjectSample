namespace HotelBookingAPI.DTOs.BookingDTOs;

public class RoomCostsResponseDTO
{
    public List<RoomCostDetailDTO> RoomDetails { get; set; } = new List<RoomCostDetailDTO>();
    public decimal Amount { get; set; }     // Base total cost before tax
    public decimal GST { get; set; }        // GST amount based on 18%
    public decimal TotalAmount { get; set; }  // Total cost including GST
    public bool Status { get; set; }
    public string Message { get; set; }
}
