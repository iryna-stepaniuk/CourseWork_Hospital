using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.BLL.DTO;
using Hospital.BLL.Services;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Infrastructure;
using Hospital.WEB.Models;


namespace Hospital.WEB.Controllers
{
    public class PatientController : Controller
    {
        IPatientService patientService;
        public PatientController(IPatientService serv)
        {
            patientService = serv;
        }

        public ActionResult Patients(string secondName)
        {
            if (!String.IsNullOrEmpty(secondName))
            {
                IEnumerable<PatientDTO> patientDtos = patientService.GetPatientsBySecondName(secondName);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, PatientViewModel>()).CreateMapper();
                var patients = mapper.Map<IEnumerable<PatientDTO>, List<PatientViewModel>>(patientDtos);
                return View(patients);
            }
            else
            {
                IEnumerable<PatientDTO> patientDtos = patientService.GetPatients();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PatientDTO, PatientViewModel>()).CreateMapper();
                var patients = mapper.Map<IEnumerable<PatientDTO>, List<PatientViewModel>>(patientDtos);
                return View(patients);
            }
        }

        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePatient(PatientViewModel patient)
        {
            try
            {
                var patientDto = new PatientDTO { Id = patient.Id, FirstName = patient.FirstName, SecondName = patient.SecondName};
                patientService.CreatePatient(patientDto);
                return RedirectToAction("Patients");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(patient);
        }
        [HttpGet]
        public ActionResult EditPatient(int? id)
        {

            PatientDTO patient = patientService.GetPatient(id);
            var patient2 = new PatientViewModel { Id = patient.Id };

            return View(patient2);

        }

        [HttpPost]
        public ActionResult EditPatient(PatientDTO patient)
        {
            try
            {
                var patientDto = new PatientDTO { Id = patient.Id, FirstName = patient.FirstName, SecondName = patient.SecondName };
                patientService.EditPatient(patientDto);
                return RedirectToAction("Patients");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View();
        }


        public ActionResult DeletePatient(int id)
        {
            if (id != null)
            {
                patientService.DeletePatient(id);

                return View();
            }
            else
                return RedirectToAction("Patients");
        }

    }
}