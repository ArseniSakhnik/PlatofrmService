using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlatofrmService.Data;
using PlatofrmService.Dtos;
using PlatofrmService.Models;
using PlatofrmService.SyncDataService.Http;

namespace PlatofrmService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(
            
            AppDbContext context, 
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _context = context;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            var platforms = await _context.Platforms.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{platformId:int}")]
        public async Task<IActionResult> GetPlatformById(int platformId)
        {
            var platform = await _context.Platforms.FirstOrDefaultAsync(platform => platform.Id == platformId);
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<Platform>(platformCreateDto);
            await _context.Platforms.AddAsync(platform);
            await _context.SaveChangesAsync();

            var platformModel = _mapper.Map<PlatformReadDto>(platform);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformModel);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"--> Could not send sync {exception.Message}");
            }
            
            return Ok(platformModel);
        }
    }
}