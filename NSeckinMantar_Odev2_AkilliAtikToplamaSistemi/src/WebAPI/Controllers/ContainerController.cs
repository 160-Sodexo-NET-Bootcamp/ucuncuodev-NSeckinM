﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.ContainerDto;

namespace WebAPI.Controllers
{
    [Route("api/v1/Containers")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContainerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //You can use the HttpGet request to take all Container list
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Containers.GetAllAsync());
        }

        //You can use this HttpGet request with id  to get just one Container object.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContainer(int id)
        {
            Container container = await _unitOfWork.Containers.GetByIdAsync(id);
            if (container == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<GetContainerDTO>(container);
            return Ok(result);
        }

        //You can use this HttpPost request to create new container's object.
        [HttpPost]
        public async Task<IActionResult> CreateContainer([FromBody] CreateContainerDTO containerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            //Container container = new()
            //{
            //    ContainerName = containerDto.ContainerName,
            //    Latitude = containerDto.Latitude,
            //    Longitude = containerDto.Longitude,
            //    VehicleId = containerDto.VehicleId,
            //};

            //mapping
            var container = _mapper.Map<Container>(containerDto);

            await _unitOfWork.Containers.AddAsync(container);
            _unitOfWork.Complete();

            return CreatedAtAction("GetContainer", new { Id = container.Id }, containerDto);
        }

        //You can use this HttpPut request to update container's object already have with using unique id.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContainer([FromRoute] int id, [FromBody] UpdateContainerDTO updateContainerDto)
        {
            if (ModelState.IsValid)
            {
                if (id != updateContainerDto.Id)
                {
                    return BadRequest("Id information is not confirmed");
                }

                var container = _mapper.Map<Container>(updateContainerDto);
                await _unitOfWork.Containers.UpdateAsync(container);

                _unitOfWork.Complete();
                return Ok("Container Updated");
            }
            return BadRequest(ModelState);

        }

        //You can use this HttpDelete request to delete container's object already have with using unique id.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            Container container = await _unitOfWork.Containers.GetByIdAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            await _unitOfWork.Containers.DeleteAsync(container);
            _unitOfWork.Complete();
            return NoContent();
        }


        //Request Url=  https://localhost:44341/api/v1/Containers/GetContanerClusters?id=1&N=2

        [Route("GetContainerClusters")]
        [HttpGet]
        public async Task<IActionResult> GetClusters(int id, int N)
        {
            List<Container[]> a = await _unitOfWork.Containers.GetVehicleWithContainersCluster(id, N);
            if (a.Count == 0)
            {
                return BadRequest("Girilen Kümesayısı Container elemanlarını eşit oranda dağıtamıyor lütfen geçerli bir değer giriniz.");
            }
            return Ok(a);
        }

    }
}
