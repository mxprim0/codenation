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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _userService = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {            
            if (accelerationName != null)
            {
                List<UserDTO> userDTOs = _userService.FindByAccelerationName(accelerationName).Select(x => _mapper.Map<UserDTO>(x)).ToList();
                return Ok(userDTOs);
            }
            else if (companyId.HasValue)
            {
                List<UserDTO> userDTOs = _userService.FindByCompanyId(companyId.Value).Select(x => _mapper.Map<UserDTO>(x)).ToList();
                return Ok(userDTOs);
            }
            else
                return NoContent();
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {            
           User user = _userService.FindById(id);
           UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                User user = _mapper.Map<User>(value);
                _userService.Save(user);
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return Ok(userDTO);
            }
        }   
     
    }
}
