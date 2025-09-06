using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.CargoCompanyDtos
{
    public class DeleteCargoCompanyDto
    {
        public int CargoCompanyId { get; set; }

        public DeleteCargoCompanyDto(int cargoCompanyId)
        {
            CargoCompanyId = cargoCompanyId;
        }
    }
}
