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
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        private readonly IMapper _mapper;

        public SubmissionController(ISubmissionService submissionService, IMapper mapper)
        {
            _submissionService = submissionService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if (challengeId.HasValue && accelerationId.HasValue)
            {
                List<SubmissionDTO> submissionDTOs = _submissionService.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value).Select(x => _mapper.Map<SubmissionDTO>(x)).ToList();
                return Ok(submissionDTOs);
            }
            else
                return NoContent();
        }

        [HttpGet("higherScore")]
        public ActionResult<decimal> GetHigherScore(int challengeId)
        {
            decimal value = _submissionService.FindHigherScoreByChallengeId(challengeId);
            return Ok(value);
        }

        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                Submission submission = _mapper.Map<Submission>(value);
                _submissionService.Save(submission);
                SubmissionDTO submissionDTO = _mapper.Map<SubmissionDTO>(submission);
                return Ok(submissionDTO);
            }
        }
    }
}
