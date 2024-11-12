using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.CustomValidateFilters;
using Microsoft.AspNetCore.Authorization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*[Authorize]*/
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;

        public RolesController(IRoleRepository roleRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from Database - Domain models
            var roleDomain = await roleRepository.GetAllAsync();
            //Convert Domain to Dto
            return Ok(mapper.Map<List<RoleDto>>(roleDomain));
        }
        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(Guid id)
        {
            //Get answer model from DB
            var roleDomain = await roleRepository.GetByIdAsync(x=>x.Id==id);

            if (roleDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
            return Ok(mapper.Map<RoleDto>(roleDomain));
        }

        // POST: api/Roles
        // To protect from overroleing attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<Role>> CreateRole([FromBody] AddRoleRequestDto addRoleDto)
        {
            //Convert DTO to Domain Model
            var roleDomain = mapper.Map<Role>(addRoleDto);

            //Use Domain Model to create Role
            roleDomain = await roleRepository.CreateAsync(roleDomain);

            //Convert Domain Model back to DTO
            var RoleDto = mapper.Map<RoleDto>(roleDomain);
            return CreatedAtAction(nameof(GetById), new { id = RoleDto.Id }, RoleDto);
        }

        // PUT: api/Roles/5
        // To protect from overroleing attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateRole(Guid id, UpdateRoleRequestDto updateRoleRequestDto)
        {
            //Map DTO to Domain Model
            var roleDomain = mapper.Map<Role>(updateRoleRequestDto);

            //Check if region exits
            roleDomain = await roleRepository.UpdateAsync(x => x.Id == id, entity =>
            {
                entity.RoleName = roleDomain.RoleName;
                entity.Description = roleDomain.Description;
                entity.UpdatedAt= roleDomain.UpdatedAt;
            });
            if (roleDomain == null) { return NotFound(); }

            //Convert Domain Model to DTO
            return Ok(mapper.Map<RoleDto>(roleDomain));

        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            //Check if region exits
            var roleDomain = roleRepository.DeleteAsync(x => x.Id == id);
            if (roleDomain == null) { return NotFound(); }

            //Map Domain Model to DTO
            return Ok(mapper.Map<Role>(roleDomain));
        }
    }
}
