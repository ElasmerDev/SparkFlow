// -----------------------------------------------------------------------------
// File: GetWorkersQuery.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Queries/GetWorkers/GetWorkersQuery.cs
// Summary:
//   Represents a request for listing workers.
//
// Responsibilities:
//   - Trigger worker listing use case
// -----------------------------------------------------------------------------

using MediatR;
using SparkFlow.Server.Contracts.Worker.Responses;

namespace SparkFlow.Server.Application.Workers.Queries.GetWorkers;

public sealed class GetWorkersQuery : IRequest<List<WorkerDto>>
{
}
