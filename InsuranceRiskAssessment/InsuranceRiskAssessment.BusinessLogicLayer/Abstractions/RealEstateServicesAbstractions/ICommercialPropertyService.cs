﻿using InsuranceRiskAssessment.DataAccessLayer.Entities.RealEstateEntities;
using System.Collections.Generic;

namespace InsuranceRiskAssessment.BusinessLogicLayer.Abstractions.RealEstateServices
{
    public interface ICommercialPropertyService
    {
        bool CreateCommercialProperty(string country, string region, string city, string address, bool fireExtinguishers,
            bool emergencyExit, double squareFeet, bool alarmSystem, bool gasBottles, bool previousIncidents, string brokerId);
        bool UpdateCommercialProperty(int commercialPropertyId, string country, string region, string city, string address, bool fireExtinguishers,
            bool emergencyExit, double squareFeet, bool alarmSystem, bool gasBottles, bool previousIncidents);
        List<CommercialProperty> GetCommercialProperty();
        CommercialProperty GetCommercialPropertyById(int commercialPropertyId);
        bool Remove(int commercialPropertyId);
    }
}
