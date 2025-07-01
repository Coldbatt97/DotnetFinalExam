using HotelBookingService.Models;

namespace HotelBookingService.Mutation
{
	/// <summary>
	/// Сервис для бронирования отелей
	/// </summary>
	public class HotelMutation
	{
		/// <summary>
		/// Забронировать отель
		/// </summary>
		/// <param name="userId">Id пользоватекля</param>
		/// <param name="hotelName">Название отеля</param>
		/// <returns>Забронированный отель</returns>
		public Hotel ReserveHotel(string userId, string hotelName)
		{
			var hotel = new Hotel { UserId = userId, HotelName = hotelName };
			Hotels.HotelsPool.Add(hotel);
			return hotel;
		}

		/// <summary>
		/// Подтвердить бронирование отеля
		/// </summary>
		/// <param name="id">Id отеля</param>
		/// <returns>Подтвержденный отель</returns>
		public Hotel ConfirmHotel(string id)
		{
			var hotel = Hotels.HotelsPool.FirstOrDefault(h => h.Id == id);
			if (hotel == null) throw new GraphQLException("Hotel not found");

			hotel.Status = "confirmed";
			return hotel;
		}

		/// <summary>
		/// Отменить бронирование отель
		/// </summary>
		/// <param name="id">Id бронирования</param>
		/// <returns>Отмененный перелет</returns>
		public Hotel CancelHotel(string id)
		{
			var hotel = Hotels.HotelsPool.FirstOrDefault(h => h.Id == id);
			if (hotel == null) throw new GraphQLException("Hotel not found");

			hotel.Status = "cancelled";
			return hotel;
		}
	}
}