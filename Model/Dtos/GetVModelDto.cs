﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.VModelDto
{
    public class GetVModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake Make { get; set; }
    }
}
