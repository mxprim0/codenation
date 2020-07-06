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
    public class CompanyController : ControllerBase
    {    
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            CompanyDTO companyDTO = _mapper.Map<CompanyDTO>(_companyService.FindById(id));
            return Ok(companyDTO);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if (accelerationId.HasValue)
            {
                List<CompanyDTO> companyDTOs = _companyService.FindByAccelerationId(accelerationId.Value).Select(x => _mapper.Map<CompanyDTO>(x)).ToList();
                return Ok(companyDTOs);
            }
            else if (userId.HasValue)
            {
                List<CompanyDTO> companyDTOs = _companyService.FindByUserId(userId.Value).Select(x => _mapper.Map<CompanyDTO>(x)).ToList();
                return Ok(companyDTOs);
            }
            else
                return NoContent();
        }

        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                Company company = _mapper.Map<Company>(value);
                _companyService.Save(company);
                CompanyDTO companyDTO = _mapper.Map<CompanyDTO>(company);
                return Ok(companyDTO);
            }
        }
    }
}
