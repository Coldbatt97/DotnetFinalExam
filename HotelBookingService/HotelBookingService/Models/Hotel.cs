namespace HotelBookingService.Models
{
	/// <summary>
	/// Отель
	/// </summary>
	public class Hotel
	{
		/// <summary>
		/// Id
		/// </summary>
		public string Id { get; set; } = Guid.NewGuid().ToString();

		/// <summary>
		/// Id пользователя
		/// </summary>
		public required string UserId { get; set; }

		/// <summary>
		/// Название отеля
		/// </summary>
		public required string HotelName { get; set; }

		/// <summary>
		/// Статус - reserved, confirmed, cancelled
		/// </summary>
		public string Status { get; set; } = "reserved";
	}
}