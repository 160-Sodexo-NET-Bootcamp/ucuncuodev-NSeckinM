using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs.ContainerDto
{
    public class GetContainerDTO : BaseDTO
    {
        public string ContainerName { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }


        public int? VehicleId { get; set; }

    }
}
