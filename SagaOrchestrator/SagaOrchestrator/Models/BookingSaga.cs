namespace SagaOrchestrator.Models
{
	/// <summary>
	/// Модель бронирований
	/// </summary>
	public class BookingSaga
	{
		/// <summary>
		/// Id бронирования
		/// </summary>
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// Id пользователя
		/// </summary>
		public required string UserId { get; set; }

		/// <summary>
		/// Id перелета
		/// </summary>
		public string? FlightId { get; set; }

		/// <summary>
		/// Id бронирования отеля
		/// </summary>
		public string? HotelId { get; set; }

		/// <summary>
		/// Статус - "pending", "completed", "failed"
		/// </summary>
		public string Status { get; set; } = "pending";
	}
}