using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class TeacherVM
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListTeacher)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Teacher> ListTeacher
        {
            get;
            set;
        } =
 new ObservableCollection<Teacher>();
        public TeacherVM()
        {
            this.ListTeacher.Add(
            new Teacher
            {
                Id = 1,
                IdChair = 1,
                IdPost = 1,
                FirstName = "Иван",
                SecondName = "Иванович",
                LastName = "Иванов",
                Phone = "8888888888",
                EMail = "IvanovII@mail.ru"
            });
            this.ListTeacher.Add(
            new Teacher
            {
                Id = 2,
                IdChair = 2,
                IdPost = 2,
                FirstName = "Александр",
                SecondName = "Александрович",
                LastName = "Александров",
                Phone = "8888888888",
                EMail = "alexandrovAA@mail.ru"
            });
            this.ListTeacher.Add(
            new Teacher
            {
                Id = 3,
                IdChair = 3,
                IdPost = 2,
                FirstName = "Олег",
                SecondName = "Олегович",
                LastName = "Олегов",
                Phone = "777777777777",
                EMail = "OlegovOO@mail.ru"
            });
        }
    }
}