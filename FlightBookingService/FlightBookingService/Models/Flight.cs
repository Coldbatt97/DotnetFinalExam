namespace FlightBookingService.Models
{
	/// <summary>
	/// Перелет
	/// </summary>
	public class Flight
	{
		/// <summary>
		/// Id перелета
		/// </summary>
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// Id пользователя
		/// </summary>
		public required string UserId { get; set; }

		/// <summary>
		/// Номер перелета
		/// </summary>
		public required string FlightNumber { get; set; }

		/// <summary>
		/// Статус - reserved, confirmed, cancelled
		/// </summary>
		public string Status { get; set; } = "reserved";
	}
}