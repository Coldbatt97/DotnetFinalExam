using SagaOrchestrator.Mutation;
using SagaOrchestrator.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddGraphQLServer()
	.AddQueryType<SagaQuery>()
	.AddMutationType<SagaMutation>();

var app = builder.Build();
app.MapGraphQL();
app.Run("http://localhost:4000");