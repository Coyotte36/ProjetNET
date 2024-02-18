﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ApiModels
{
    public class VehicleModel
    {
            public int Id { get; set; }
            public string Brand { get; set; }
            public ModelModel Model { get; set; }
            public int Year { get; set; }
            public int Mileage { get; set; }
            public string Matriculation { get; set; }
            public EnergyType Energie { get; set; }
    }
}