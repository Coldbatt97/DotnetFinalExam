using FlightBookingService.Models;

namespace FlightBookingService.Mutation
{
	/// <summary>
	/// Сервис для бронирования перелетов
	/// </summary>
	public class FlightMutation
	{
		/// <summary>
		/// Забронировать перелет
		/// </summary>
		/// <param name="userId">Id пользоватекля</param>
		/// <param name="flightNumber">Номер перелета</param>
		/// <returns>Забронированный перелет</returns>
		public Flight ReserveFlight(string userId, string flightNumber)
		{
			var flight = new Flight { UserId = userId, FlightNumber = flightNumber };
			Flights.FlightsPool.Add(flight);
			return flight;
		}

		/// <summary>
		/// Подтвердить перелет
		/// </summary>
		/// <param name="id">Id перелета</param>
		/// <returns>Подтвержденный перелет</returns>
		public Flight ConfirmFlight(string id)
		{
			var flight = Flights.FlightsPool.FirstOrDefault(f => f.Id == id);
			if (flight == null) throw new GraphQLException("Flight not found");

			flight.Status = "confirmed";
			return flight;
		}

		/// <summary>
		/// Отменить перелет
		/// </summary>
		/// <param name="id">Id перелета</param>
		/// <returns>Отмененный перелет</returns>
		public Flight CancelFlight(string id)
		{
			var flight = Flights.FlightsPool.FirstOrDefault(f => f.Id == id);
			if (flight == null) throw new GraphQLException("Flight not found");

			flight.Status = "cancelled";
			return flight;
		}
	}
}