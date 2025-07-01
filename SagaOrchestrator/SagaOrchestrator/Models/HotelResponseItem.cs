using Newtonsoft.Json;

namespace SagaOrchestrator.Models
{
	/// <summary>
	/// Ответ от сервиса бронирования отелей
	/// </summary>
	public class HotelResponseItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }
	}
}