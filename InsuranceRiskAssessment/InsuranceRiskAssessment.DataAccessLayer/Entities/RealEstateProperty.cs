﻿namespace InsuranceRiskAssessment.DataAccessLayer.Entities
{
    public abstract class RealEstateProperty : BaseEntity
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool FireExtinguishers { get; set; }
        public bool EmergencyExit { get; set; }
        public double SquareFeet { get; set; }
        public bool AlarmSystem { get; set; }
        public bool GasBottles { get; set; }

    }
}
