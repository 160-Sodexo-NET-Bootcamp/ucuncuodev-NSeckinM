using ApplicationCore.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.ContainerDto;
using WebAPI.DTOs.VehicleDto;

namespace WebAPI
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
             CreateMap<Container,CreateContainerDTO>().ReverseMap();
             CreateMap<Container,UpdateContainerDTO>().ReverseMap();
             CreateMap<Container, GetContainerDTO>().ReverseMap();

            CreateMap<Vehicle,UpdateVehicleDTO>().ReverseMap();
             CreateMap<Vehicle, CreateVehicleDTO>().ReverseMap();
            CreateMap<Vehicle, GetVehicleDTO>().ReverseMap();


        }




    }
}
