using HotelBookingService.Mutation;
using HotelBookingService.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddGraphQLServer()
	.AddQueryType<HotelQuery>()
	.AddMutationType<HotelMutation>();

var app = builder.Build();
app.MapGraphQL();
app.Run("http://localhost:4002");