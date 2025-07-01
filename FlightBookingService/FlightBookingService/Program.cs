using FlightBookingService.Mutation;
using FlightBookingService.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddGraphQLServer()
	.AddQueryType<FlightQuery>()
	.AddMutationType<FlightMutation>();

var app = builder.Build();
app.MapGraphQL();
app.Run("http://localhost:4001");