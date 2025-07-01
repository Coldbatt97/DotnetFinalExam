using Newtonsoft.Json;

namespace SagaOrchestrator.Models
{
	/// <summary>
	/// Ответ от сервиса бронирования перелетов
	/// </summary>
	public class FlightResponse
	{
		[JsonProperty("reserveFlight")]
		public FlightResponseItem ReserveFlight { get; set; }

		[JsonProperty("confirmFlight")]
		public FlightResponseItem ConfirmFlight { get; set; }

		[JsonProperty("cancelFlight")]
		public FlightResponseItem CancelFlight { get; set; }
	}
}