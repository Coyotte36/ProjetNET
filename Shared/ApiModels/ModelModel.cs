using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ApiModels
{
    public class ModelModel
    {
            public int Id { get; set; }
            public string Brand { get; set; }
            public int MaintenanceFrequency { get; set; }
            public string Description { get; set; }
    }
}