using HotelBookingService.Models;

namespace HotelBookingService.Query
{
	/// <summary>
	/// Сервис для получения данных о бронированиях отелей
	/// </summary>
	public class HotelQuery
	{
		/// <summary>
		/// Получить конкретный отель
		/// </summary>
		/// <param name="id">Id бронирования</param>
		/// <returns>Отель</returns>
		public Hotel? GetHotel(string id) => Hotels.HotelsPool.FirstOrDefault(h => h.Id == id);

		/// <summary>
		/// Получить все бронирования отелей
		/// </summary>
		/// <returns>Список бронирований</returns>
		public List<Hotel> GetHotels() => Hotels.HotelsPool;
	}
}