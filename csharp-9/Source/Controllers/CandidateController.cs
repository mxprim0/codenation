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
    public class CandidateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _mapper = mapper;
            _candidateService = candidateService;
        }

        [HttpGet("{userId}/{accelerationId}/{companyId}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyId)
        {
            Candidate candidate = _candidateService.FindById(userId, accelerationId,companyId);
            CandidateDTO candidateDTO = null;

            if (candidate != null)
                candidateDTO = _mapper.Map<CandidateDTO>(candidate);
            return candidateDTO;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if (companyId.HasValue)
            {
                    List<CandidateDTO> candidateDTOs = _candidateService.FindByCompanyId(companyId.Value).Select(x => _mapper.Map<CandidateDTO>(x)).ToList();
                    return Ok(candidateDTOs);
            }
            else if (accelerationId.HasValue)
            {
                List<CandidateDTO> candidateDTOs = _candidateService.FindByCompanyId(accelerationId.Value).Select(x => _mapper.Map<CandidateDTO>(x)).ToList();
                return Ok(candidateDTOs);
            }
            else
                return NoContent();

        }

        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                Candidate candidate = _mapper.Map<Candidate>(value);
                _candidateService.Save(candidate);
                CandidateDTO candidateDTO = _mapper.Map<CandidateDTO>(candidate);
                return Ok(candidateDTO);
            }
        }

    }
}
