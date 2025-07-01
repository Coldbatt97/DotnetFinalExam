using FlightBookingService.Models;

namespace FlightBookingService
{
	/// <summary>
	/// "БАЗА ДАННЫХ" перелетов
	/// </summary>
	public static class Flights
	{
		/// <summary>
		/// Все перелеты
		/// </summary>
		public static List<Flight> FlightsPool = new();
	}
}