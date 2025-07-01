using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using SagaOrchestrator.Models;

namespace SagaOrchestrator.Mutation
{
    /// <summary>
    /// Сервис бронирования всего (оркестрант)
    /// </summary>
    public class SagaMutation
    {
        private readonly IGraphQLClient _flightClient;
        private readonly IGraphQLClient _hotelClient;

        /// <summary>
        /// Конструктор
        /// </summary>
        public SagaMutation()
        {
            _flightClient = new GraphQLHttpClient("http://localhost:4001/graphql", new NewtonsoftJsonSerializer());
            _hotelClient = new GraphQLHttpClient("http://localhost:4002/graphql", new NewtonsoftJsonSerializer());
        }

        /// <summary>
        /// Начать бронирование
        /// </summary>
        /// <param name="userId">Id пользовтеля</param>
        /// <param name="flightNumber">Номер перелета</param>
        /// <param name="hotelName">НАименование отеля</param>
        /// <returns></returns>
        public async Task<BookingSaga> StartBooking(string userId, string flightNumber, string hotelName)
        {
            var saga = new BookingSaga { UserId = userId };

            try
            {
                #region Бронирование

                var flightRequest = new GraphQL.GraphQLRequest()
                {
                    Query = @"
                    mutation ($userId: String!, $flightNumber: String!) {
                        reserveFlight(userId: $userId, flightNumber: $flightNumber) { id }
                    }",
                    Variables = new { userId, flightNumber }
                };
                var flightResponse = await _flightClient.SendMutationAsync<FlightResponse>(flightRequest);
                saga.FlightId = flightResponse.Data.ReserveFlight.Id;

                var hotelRequest = new GraphQL.GraphQLRequest()
                {
                    Query = @"
                    mutation ($userId: String!, $hotelName: String!) {
                        reserveHotel(userId: $userId, hotelName: $hotelName) { id }
                    }",
                    Variables = new { userId, hotelName }
                };

                var hotelResponse = await _hotelClient.SendMutationAsync<HotelResponse>(hotelRequest);
                saga.HotelId = hotelResponse.Data.ReserveHotel.Id;

                #endregion

                #region Подтверждение бронирований

                // 3. Подтверждаем бронирования
                await _flightClient.SendMutationAsync<FlightResponse>(new GraphQL.GraphQLRequest()
                {
                    Query = "mutation ($id: String!) { confirmFlight(id: $id) { id } }",
                    Variables = new { id = saga.FlightId }
                });

                await _hotelClient.SendMutationAsync<HotelResponse>(new GraphQL.GraphQLRequest()
                {
                    Query = "mutation ($id: String!) { confirmHotel(id: $id) { id } }",
                    Variables = new { id = saga.HotelId }
                });

                #endregion

                saga.Status = "completed";
                return saga;
            }
            catch (Exception)
            {
                if (saga.FlightId != null)
                {
                    var cancelFlightRequest = new GraphQL.GraphQLRequest()
                    {
                        Query = @"
                            mutation ($id: String!) {
                                cancelFlight(id: $id) {
                                    id
                                    status
                                }
                            }",
                        Variables = new { id = saga.FlightId }
                    };
                    await _flightClient.SendMutationAsync<FlightResponse>(cancelFlightRequest);
                }

                if (saga.HotelId != null)
                {
                    var cancelHotelRequest = new GraphQL.GraphQLRequest()
                    {
                        Query = @"
                            mutation ($id: String!) {
                                cancelHotel(id: $id) {
                                    id
                                    status
                                }
                            }",
                        Variables = new { id = saga.HotelId }
                    };
                    await _hotelClient.SendMutationAsync<HotelResponse>(cancelHotelRequest);
                }

                saga.Status = "failed";
                return saga;
            }
        }
    }
}