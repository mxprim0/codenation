using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;
        private readonly IMapper _mapper;

        public ChallengeController(IChallengeService challengeService, IMapper mapper)
        {
            _challengeService = challengeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId.HasValue && userId.HasValue)
            {
                List<ChallengeDTO> challengeDTOs = _challengeService.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value).Select(x => _mapper.Map<ChallengeDTO>(x)).ToList();
                return Ok();
            }
            else
                return NoContent();
        }

        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                Models.Challenge challenge = _mapper.Map<Models.Challenge>(value);
                _challengeService.Save(challenge);
                ChallengeDTO challengeDTO = _mapper.Map<ChallengeDTO>(challenge);
                    return Ok(challengeDTO);
            }
        }
    }
}
