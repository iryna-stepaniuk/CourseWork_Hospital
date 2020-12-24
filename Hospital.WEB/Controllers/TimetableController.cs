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
    public class TimetableController: Controller
    {
        ITimetableService timetableService;
        public TimetableController(ITimetableService serv)
        {
            timetableService = serv;
        }

        public ActionResult Timetables()
        {
            
                IEnumerable<TimetableDTO> timetableDtos = timetableService.GetTimetables();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimetableDTO, TimetableViewModel>()).CreateMapper();
                var timetables = mapper.Map<IEnumerable<TimetableDTO>, List<TimetableViewModel>>(timetableDtos);
                return View(timetables);
            
        }

        [HttpGet]
        public ActionResult CreateTimetable()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTimetable(TimetableViewModel timetable)
        {
            try
            {
                var timetableDto = new TimetableDTO { DoctorId = timetable.DoctorId, PatientId=timetable.PatientId, StartTime=timetable.StartTime, EndTime=timetable.EndTime};
                timetableService.CreateTimetable(timetableDto);
                return RedirectToAction("Timetables");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(timetable);
        }
    }
}