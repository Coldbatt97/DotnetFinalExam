using FlightBookingService.Models;

namespace FlightBookingService.Query
{
	/// <summary>
	/// Сервис для получения данных о перелтах
	/// </summary>
	public class FlightQuery
	{
		/// <summary>
		/// Получить конкретный переелт
		/// </summary>
		/// <param name="id">Id бронирования</param>
		/// <returns>Перелет</returns>
		public Flight? GetFlight(string id) => Flights.FlightsPool.FirstOrDefault(f => f.Id == id);

		/// <summary>
		/// Получить все перелеты
		/// </summary>
		/// <returns>Список бронирований</returns>
		public List<Flight> GetFlights() => Flights.FlightsPool;
	}
}