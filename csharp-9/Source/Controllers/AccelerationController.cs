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
    public class AccelerationController : ControllerBase
    {    
        private IMapper _mapper;
        private IAccelerationService _accelerationService;

        public AccelerationController(IAccelerationService accelerationService, IMapper mapper)
        {
            _mapper = mapper;
            _accelerationService = accelerationService;
        }

        [HttpGet("{id}")]
        public ActionResult<AccelerationDTO> Get(int id)
        {
            Acceleration acceleration = _accelerationService.FindById(id);
            AccelerationDTO accelerationDTO = null;

            if (acceleration != null)
                accelerationDTO = _mapper.Map<AccelerationDTO>(acceleration);
            return Ok(accelerationDTO);

        }

        [HttpGet]
        public ActionResult<List<AccelerationDTO>> GetAll(int? companyId)
         {
            if (companyId != null)
            {
                List<AccelerationDTO> accelerationDtoList = _accelerationService.FindByCompanyId(companyId.Value).Select(x => _mapper.Map<AccelerationDTO>(x)).ToList();
                return Ok(accelerationDtoList);
            }
            else
                return NoContent();

         }

        [HttpPost]
        public Acceleration Post([FromBody] AccelerationDTO accelerationDTO)
        {
            Acceleration acceleration = _mapper.Map<Acceleration>(accelerationDTO);
            return _accelerationService.Save(acceleration);
        }
    }
}
