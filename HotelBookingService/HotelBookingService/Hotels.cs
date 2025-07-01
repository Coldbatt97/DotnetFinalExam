using HotelBookingService.Models;

namespace HotelBookingService
{
	/// <summary>
	/// "БАЗА ДАННЫХ" бронирования отелей
	/// </summary>
	public class Hotels
	{
		/// <summary>
		/// Все бронирования отелей
		/// </summary>
		public static List<Hotel> HotelsPool = new();

	}
}