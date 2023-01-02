﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Chair
    {
        public Chair CopyFromChairDPO(ChairDPO p)
        {
            FacultyVM vmFac = new FacultyVM();
            int facId = 0;
            foreach (var s in vmFac.ListFaculty)
            {
                if (s.NameFaculty == p.NameFaculty)
                {
                    facId = s.Id;
                    break;
                }
            }
            if (facId != 0 )
            {
                this.Id = p.Id;
                this.IdFaculty = IdFaculty;
                this.Code = p.Code;
                this.NameChair = p.NameChair;
                this.ShortNameChair = p.ShortNameChair;
            }
            return this;
        }
        public int Id { get; set; }
        public int IdFaculty { get; set; }
        public int Code { get; set; }
        public string NameChair { get; set; }
        public string ShortNameChair { get; set; }
        public Chair() { }
        public Chair(int id, int idFaculty, int code, string nameChair, string snChair)
        {
            this.Id = id;
            this.IdFaculty = idFaculty;
            this.Code = code;
            this.NameChair = nameChair;
            this.ShortNameChair = snChair;
        }
    }
}