﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsuranceRiskAssessment.DataAccessLayer.Data;
using InsuranceRiskAssessment.DataAccessLayer.Entities.MovablePropertyEnities;
using InsuranceRiskAssessment.BusinessLogicLayer.Abstractions.MovablePropertyServices;
using InsuranceRiskAssessment.Web.Models.ViewModels.MovableProprtiesViewModels.VehicleByLand;
using InsuranceRiskAssessment.Web.Models.ViewModels.MovableProprtiesViewModels.SeaTransport;

namespace InsuranceRiskAssessment.Web.Controllers.MovablePropertiesControllers
{
    public class VehicleByLandsController : Controller
    {
        private readonly IVehicleByLandService _vehicleByLandService;

        public VehicleByLandsController(IVehicleByLandService vehicleByLandService)
        {
            _vehicleByLandService = vehicleByLandService;
        }

        // GET: VehicleByLands
        public ActionResult Index()
        {
            List<VehicleByLandViewModel> vehiclesByLand = _vehicleByLandService.GetVehiclesByLand()
              .Select(item => new VehicleByLandViewModel()
              {
                  Id = item.Id,
                  ManifactureYear = item.ManifactureYear,
                  SecurityEquipmenPossession = item.SecurityEquipmenPossession,
                  TechnicalServiceability = item.TechnicalServiceability,
                  DistanceTraveled = item.DistanceTraveled,
                  Height = item.Height,
                  Weight = item.Weight,
                  Width = item.Width,
                  RegisteredCountry = item.RegisteredCountry,
                  RegisteredRegion = item.RegisteredRegion,
                  RegisteredCity = item.RegisteredCity,
                  CreatedAt = item.CreatedAt,
                  ModifiedAt = item.ModifiedAt,
                  PreviousAccidents = item.PreviousAccidents,
                  FuelType = item.FuelType,
                  RegisterNumber = item.RegisterNumber,
                  Parktronic = item.Parktronic,
                  MostCommonRoutes = item.MostCommonRoutes,
                  ResultValue = item.ResultValue

              }).ToList();

            return View(vehiclesByLand);

        }

        // GET: VehicleByLands/Details/5
        public ActionResult Details(int id)
        {
            var item = _vehicleByLandService.GetVehicleByLandById(id);
            VehicleByLandDetailsViewModel model = new VehicleByLandDetailsViewModel()
            {
                Id = item.Id,
                ManifactureYear = item.ManifactureYear,
                SecurityEquipmenPossession = item.SecurityEquipmenPossession,
                TechnicalServiceability = item.TechnicalServiceability,
                DistanceTraveled = item.DistanceTraveled,
                Height = item.Height,
                Weight = item.Weight,
                Width = item.Width,
                RegisteredCountry = item.RegisteredCountry,
                RegisteredRegion = item.RegisteredRegion,
                RegisteredCity = item.RegisteredCity,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt,
                PreviousAccidents = item.PreviousAccidents,
                FuelType = item.FuelType,
                RegisterNumber = item.RegisterNumber,
                Parktronic = item.Parktronic,
                MostCommonRoutes = item.MostCommonRoutes,
                ResultValue = item.ResultValue
            };
            return View(model);
        }

        // GET: VehicleByLands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleByLands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] VehicleByLandAddViewModel model)
        {
            var created = _vehicleByLandService.CreateVehicleByLand(model.ManifactureYear, model.SecurityEquipmenPossession, model.TechnicalServiceability,
                model.DistanceTraveled, model.Height, model.Weight, model.Width, model.RegisteredCountry, model.RegisteredRegion,
                model.RegisteredCity, model.FuelType, model.Parktronic, model.MostCommonRoutes, model.RegisterNumber);

            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: VehicleByLands/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _vehicleByLandService.GetVehicleByLandById(id);
            if (entity == null)
            {
                return NotFound();
            }

            VehicleByLandDetailsViewModel model = new VehicleByLandDetailsViewModel()
            {
                Id = entity.Id,
                ManifactureYear = entity.ManifactureYear,
                SecurityEquipmenPossession = entity.SecurityEquipmenPossession,
                TechnicalServiceability = entity.TechnicalServiceability,
                DistanceTraveled = entity.DistanceTraveled,
                Height = entity.Height,
                Weight = entity.Weight,
                Width = entity.Width,
                RegisteredCountry = entity.RegisteredCountry,
                RegisteredRegion = entity.RegisteredRegion,
                RegisteredCity = entity.RegisteredCity,
                CreatedAt = entity.CreatedAt,
                ModifiedAt = entity.ModifiedAt,
                PreviousAccidents = entity.PreviousAccidents,
                FuelType = entity.FuelType,
                RegisterNumber = entity.RegisterNumber,
                Parktronic = entity.Parktronic,
                MostCommonRoutes = entity.MostCommonRoutes,
                ResultValue = entity.ResultValue
            };
            return View(model);
        }

        // POST: VehicleByLands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleByLand model)
        {
            var updated = _vehicleByLandService.UpdateVehicleByLand(id, model.ManifactureYear, model.SecurityEquipmenPossession, model.TechnicalServiceability,
                model.DistanceTraveled, model.Height, model.Weight, model.Width, model.RegisteredCountry, model.RegisteredRegion,
                model.RegisteredCity, model.FuelType, model.Parktronic, model.MostCommonRoutes, model.RegisterNumber);

            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: VehicleByLands/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _vehicleByLandService.GetVehicleByLandById(id);
            VehicleByLandDetailsViewModel model = new VehicleByLandDetailsViewModel()
            {
                Id = item.Id,
                ManifactureYear = item.ManifactureYear,
                SecurityEquipmenPossession = item.SecurityEquipmenPossession,
                TechnicalServiceability = item.TechnicalServiceability,
                DistanceTraveled = item.DistanceTraveled,
                Height = item.Height,
                Weight = item.Weight,
                Width = item.Width,
                RegisteredCountry = item.RegisteredCountry,
                RegisteredRegion = item.RegisteredRegion,
                RegisteredCity = item.RegisteredCity,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt,
                PreviousAccidents = item.PreviousAccidents,
                FuelType = item.FuelType,
                RegisterNumber = item.RegisterNumber,
                Parktronic = item.Parktronic,
                MostCommonRoutes = item.MostCommonRoutes,
                ResultValue = item.ResultValue
            };
            return View(model);
        }

        // POST: VehicleByLands/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleted = _vehicleByLandService.Remove(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
