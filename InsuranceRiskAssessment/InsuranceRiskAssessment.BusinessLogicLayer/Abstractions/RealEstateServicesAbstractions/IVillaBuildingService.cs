﻿using InsuranceRiskAssessment.DataAccessLayer.Entities.RealEstateEntities;
using System.Collections.Generic;

namespace InsuranceRiskAssessment.BusinessLogicLayer.Abstractions.RealEstateServices
{
    public interface IVillaBuildingService
    {
        bool CreateVillaBuilding(string country, string region, string city, string address, bool fireExtinguishers,
            bool emergencyExit, double squareFeet, bool alarmSystem, bool gasBottles, bool previousIncidents, string brokerId);
        bool UpdateVillaBuilding(int villaBuildingId, string country, string region, string city, string address, bool fireExtinguishers,
            bool emergencyExit, double squareFeet, bool alarmSystem, bool gasBottles, bool previousIncidents);
        List<VillaBuilding> GetVillaBuildings();
        VillaBuilding GetVillaBuildingById(int villaBuildingId);
        bool Remove(int villaBuildingId);
    }
}
