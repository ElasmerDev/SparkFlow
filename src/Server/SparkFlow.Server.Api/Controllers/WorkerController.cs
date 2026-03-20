// -----------------------------------------------------------------------------
// File: WorkerController.cs
// Path: ./src/Server/SparkFlow.Server.Api/Controllers/WorkerController.cs
// Summary:
//   Exposes worker-related HTTP endpoints.
//
// Responsibilities:
//   - Accept registration requests
//   - Accept heartbeat requests
//   - Return worker list data
//
// Notes:
//   - Business logic is delegated to the application layer.
//   - Keep this controller thin and endpoint-focused.
// -----------------------------------------------------------------------------

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SparkFlow.Server.Application.Workers.Commands.Heartbeat;
using SparkFlow.Server.Application.Workers.Commands.RegisterWorker;
using SparkFlow.Server.Application.Workers.Queries.GetWorkers;
using SparkFlow.Server.Contracts.Worker.Requests;

namespace SparkFlow.Server.Api.Controllers;

[ApiController]
[Route("api/workers")]
public sealed class WorkerController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registers a new worker and returns its identity data.
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterWorkerRequest request)
    {
        if (request is null)
        {
            return BadRequest("Invalid request.");
        }

        var command = new RegisterWorkerCommand(
            request.InstallationId,
            request.MachineFingerprint,
            request.ProtocolVersion.ToString(),
            request.DisplayName,
            request.HostName);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    /// <summary>
    /// Updates worker liveness using its worker key.
    /// </summary>
    [HttpPost("heartbeat")]
    public async Task<IActionResult> Heartbeat([FromBody] HeartbeatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.WorkerKey))
        {
            return BadRequest("WorkerKey is required.");
        }

        var result = await _mediator.Send(new HeartbeatCommand(request.WorkerKey));

        if (!result)
        {
            return Unauthorized();
        }

        return Ok();
    }

    /// <summary>
    /// Returns all registered workers.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetWorkers()
    {
        var result = await _mediator.Send(new GetWorkersQuery());
        return Ok(result);
    }
}
