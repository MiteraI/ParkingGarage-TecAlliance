﻿using ParkingGarage.Dto.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarage.Dto.Ticket
{
    public class CreateTicketDto
    {
        [LicenseNumberValidation]
        [Required]
        public string LicensePlateNumber { get; set; }
    }
}
