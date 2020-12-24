using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Infrastructure;
using Hospital.BLL.Interfaces;
using Hospital.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.WEB.Controllers
{
    public class DoctorController : Controller
    {
        IDoctorService doctorService;
        public DoctorController(IDoctorService serv)
        {
            doctorService = serv;
        }

        public ActionResult Doctors(string secondName)
        {
            if (!String.IsNullOrEmpty(secondName))
            {
                IEnumerable<DoctorDTO> doctorDtos = doctorService.GetDoctorsBySecondName(secondName);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorViewModel>()).CreateMapper();
                var doctors = mapper.Map<IEnumerable<DoctorDTO>, List<DoctorViewModel>>(doctorDtos);
                return View(doctors);
            }
            else
            {
                IEnumerable<DoctorDTO> doctorDtos = doctorService.GetDoctors();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DoctorDTO, DoctorViewModel>()).CreateMapper();
                var doctors = mapper.Map<IEnumerable<DoctorDTO>, List<DoctorViewModel>>(doctorDtos);
                return View(doctors);
            }
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDoctor(DoctorViewModel doctor)
        {
            try
            {
                var doctorDto = new DoctorDTO { Id = doctor.Id, FirstName = doctor.FirstName, SecondName = doctor.SecondName, Specialization = doctor.Specialization };
                doctorService.CreateDoctor(doctorDto);
                return RedirectToAction("Doctors");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(doctor);
        }
        [HttpGet]
        public ActionResult EditDoctor(int? id)
        {

            DoctorDTO doctor = doctorService.GetDoctor(id);
            var doctor2 = new DoctorViewModel { Id = doctor.Id };

            return View(doctor2);

        }

        [HttpPost]
        public ActionResult EditDoctor(DoctorDTO doctor)
        {
            try
            {
                var doctorDto = new DoctorDTO { Id = doctor.Id, FirstName = doctor.FirstName, SecondName = doctor.SecondName, Specialization = doctor.Specialization };
                doctorService.EditDoctor(doctorDto);
                return RedirectToAction("Doctors");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View();
        }

        public ActionResult DeleteDoctor(int id)
        {
            if (id != null)
            {
                doctorService.DeleteDoctor(id);

                return View();
            }
            else
                return RedirectToAction("Doctors");
        }


    }
}