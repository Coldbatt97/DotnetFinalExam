using Newtonsoft.Json;

namespace SagaOrchestrator.Models
{
	/// <summary>
	/// Ответ от сервиса бронирования перелетов
	/// </summary>
	public class FlightResponseItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }
	}
}