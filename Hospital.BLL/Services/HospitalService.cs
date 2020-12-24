using AutoMapper;
using Hospital.BLL.DTO;
using Hospital.BLL.Infrastructure;
using Hospital.BLL.Interfaces;
using Hospital.DAL.Entities;
using Hospital.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.BLL.Services
{
    public class HospitalService: IHospitalService
    {
        IUnitOfWork Database { get; set; }

        public HospitalService(IUnitOfWork uow)
        {
            Database = uow;
        }
       
       



        public void Dispose()
        {
            Database.Dispose();
        }

      

    }
}

