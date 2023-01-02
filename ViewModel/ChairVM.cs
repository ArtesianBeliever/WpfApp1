﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class ChairVM
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListChair)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Chair> ListChair
        {
            get;
            set;
        } =
 new ObservableCollection<Chair>();
        public ChairVM()
        {
            this.ListChair.Add(new Chair
            {
                Id = 1,
                IdFaculty = 1,
                Code = 09,
                NameChair = "Кафедра Компьютерных Технологий и Информационной безопасности",
                ShortNameChair = "КТиБ"
            });
            this.ListChair.Add(new Chair
            {
                Id = 2,
                IdFaculty = 2,
                Code = 02,
                NameChair = "Кафедра Права",
                ShortNameChair = "КП"
            });
            this.ListChair.Add(new Chair
            {
                Id = 3,
                IdFaculty = 2,
                Code = 01,
                NameChair = "Кафедра Экономики и Финансов",
                ShortNameChair = "КЭФ"
            });
        }
    }
}