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
    public class PatientCardController: Controller
    {
        IPatientCardService patientCardService;
        IPatientService patientService;
        public PatientCardController(IPatientCardService serv, IPatientService serv2)
        {
            patientCardService = serv;
            patientService = serv2;
        }


        public ActionResult PatientCards(int id)
        {
                IEnumerable<PatientCardDTO> patientCardDtos = patientCardService.GetPatientCardsById(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PatientCardDTO, PatientCardViewModel>()).CreateMapper();
                var patientCards = mapper.Map<IEnumerable<PatientCardDTO>, List<PatientCardViewModel>>(patientCardDtos);
                return View(patientCards);
           
        }

        public ActionResult CreatePatientCard(int id)
        {
            try
            {
                PatientDTO patient = patientService.GetPatient(id);
                var patientCard = new PatientCardViewModel { PatientId = patient.Id };

                return View(patientCard);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult CreatePatientCard(PatientCardViewModel patientCard)
        {
            try
            {
                var patientCardDto = new PatientCardDTO { PatientId = patientCard.PatientId, TextInfo = patientCard.TextInfo };
                patientCardService.CreatePatientCard(patientCardDto);
                return View("../Home/Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(patientCard);
        }

    }
}
