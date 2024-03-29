﻿using InsuranceRiskAssessment.BusinessLogicLayer.Abstractions.RealEstateServices;
using InsuranceRiskAssessment.Web.Models.ViewModels.RealEstateViewModels.CommercialProperty;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace InsuranceRiskAssessment.Web.Controllers.RealEstateControllers
{
    public class CommercialPropertiesController : Controller
    {
        private readonly ICommercialPropertyService _commercialPropertyService;
        public CommercialPropertiesController(ICommercialPropertyService commercialPropertyService)
        {
            _commercialPropertyService = commercialPropertyService;
        }
        public ActionResult Index()
        {
            List<CommercialPropertyViewModel> commercialProperties = _commercialPropertyService.GetCommercialProperty()
                .Select(item => new CommercialPropertyViewModel()
                {
                    Id = item.Id,
                    Country = item.Country,
                    Region = item.Region,
                    City = item.City,
                    Address = item.Address,
                    FireExtinguishers = item.FireExtinguishers,
                    EmergencyExit = item.EmergencyExit,
                    SquareFeet = item.SquareFeet,
                    AlarmSystem = item.AlarmSystem,
                    GasBottles = item.GasBottles,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt,
                    PreviousAccidents = item.PreviousAccidents,
                    ResultValue = item.ResultValue,
                    InsuranceBroker = item.InsuranceBroker
                }).ToList();
            return View(commercialProperties);
        }
        public ActionResult Details(int id)
        {
            var item = _commercialPropertyService.GetCommercialPropertyById(id);
            CommercialPropertyDetailViewModel model = new CommercialPropertyDetailViewModel()
            {
                Id = item.Id,
                Country = item.Country,
                Region = item.Region,
                City = item.City,
                Address = item.Address,
                FireExtinguishers = item.FireExtinguishers,
                EmergencyExit = item.EmergencyExit,
                SquareFeet = item.SquareFeet,
                AlarmSystem = item.AlarmSystem,
                GasBottles = item.GasBottles,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt,
                PreviousAccidents = item.PreviousAccidents,
                ResultValue = item.ResultValue,
            };
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CommercialPropertyAddViewModel model)
        {
            var created = _commercialPropertyService.CreateCommercialProperty(model.Country, model.Region,
                model.City, model.Address, model.FireExtinguishers, model.EmergencyExit, model.SquareFeet, model.AlarmSystem,
                model.GasBottles,model.PreviousAccidents, User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var entity = _commercialPropertyService.GetCommercialPropertyById(id);
            if (entity == null)
            {
                return NotFound();
            }
            CommercialPropertyEditViewModel model = new CommercialPropertyEditViewModel()
            {
                Id = entity.Id,
                Country = entity.Country,
                Region = entity.Region,
                City = entity.City,
                Address = entity.Address,
                FireExtinguishers = entity.FireExtinguishers,
                EmergencyExit = entity.EmergencyExit,
                SquareFeet = entity.SquareFeet,
                AlarmSystem = entity.AlarmSystem,
                GasBottles = entity.GasBottles,
                CreatedAt = entity.CreatedAt,
                ModifiedAt = entity.ModifiedAt,
                PreviousAccidents = entity.PreviousAccidents,
                ResultValue = entity.ResultValue
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommercialPropertyEditViewModel model)
        {
            var updated = _commercialPropertyService.UpdateCommercialProperty(id, model.Country, model.Region,
                model.City, model.Address, model.FireExtinguishers, model.EmergencyExit, model.SquareFeet, model.AlarmSystem,
                model.GasBottles, model.PreviousAccidents);
            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var item = _commercialPropertyService.GetCommercialPropertyById(id);
            CommercialPropertyDetailViewModel model = new CommercialPropertyDetailViewModel()
            {
                Id = item.Id,
                Country = item.Country,
                Region = item.Region,
                City = item.City,
                Address = item.Address,
                FireExtinguishers = item.FireExtinguishers,
                EmergencyExit = item.EmergencyExit,
                SquareFeet = item.SquareFeet,
                AlarmSystem = item.AlarmSystem,
                GasBottles = item.GasBottles,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt,
                PreviousAccidents = item.PreviousAccidents,
                ResultValue = item.ResultValue
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _commercialPropertyService.Remove(id);
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
