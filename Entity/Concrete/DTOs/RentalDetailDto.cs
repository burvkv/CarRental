using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerFullName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
