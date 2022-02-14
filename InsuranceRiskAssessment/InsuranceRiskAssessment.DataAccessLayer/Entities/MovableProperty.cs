﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceRiskAssessment.DataAccessLayer.Entities
{
    public abstract class MovableProperty : BaseEntity
    {
        public DateTime ManifactureYear { get; set; }
        public bool SecurityEquipmenPossession { get; set; }
        public bool TechnicalServiceability { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public string RegisteredCountry { get; set; }
        public string RegisteredRegion { get; set; }
        public string RegisteredCity { get; set; }

    }
}
