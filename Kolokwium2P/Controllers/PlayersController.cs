﻿using Kolokwium2P.Model.DTO;
using Kolokwium2P.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2P.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;
    
    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPurchasesAsync(int id, CancellationToken token)
    {
        var response = await _playerService.GetPlayerMatchesForGivenIdAsync(id, token);
        return Ok(response);
    }
    
    [HttpPost]
    public Task<IActionResult> InsertNewPlayerWithPlayerMatches([FromBody] InsertPlayerWithPlayerMatchesRequest insertPlayerWithPlayerMatchesRequest)
    {
        _playerService.InsertNewPlayerWithPlayerMatches(insertPlayerWithPlayerMatchesRequest);
        return Task.FromResult<IActionResult>(Ok());
    }
}

