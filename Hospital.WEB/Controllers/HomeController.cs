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
    public class HomeController : Controller
    {
        //IHospitalService hospitalService;
        //public HomeController(IHospitalService serv)
        //{
        //    hospitalService = serv;
        //}
        public ActionResult Index()
        {
            return View();
        }

    }
}