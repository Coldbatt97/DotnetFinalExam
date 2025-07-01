using Newtonsoft.Json;

namespace SagaOrchestrator.Models
{
	/// <summary>
	/// Ответ от сервиса бронирования отелей
	/// </summary>
	public class HotelResponse
	{
		[JsonProperty("reserveHotel")]
		public HotelResponseItem ReserveHotel { get; set; }

		[JsonProperty("confirmHotel")]
		public HotelResponseItem ConfirmHotel { get; set; }

		[JsonProperty("cancelHotel")]
		public HotelResponseItem CancelHotel { get; set; }
	}
}