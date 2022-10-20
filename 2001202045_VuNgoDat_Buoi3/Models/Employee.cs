using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001202045_VuNgoDat_Buoi3.Models
{
    public class Employee
    {
        [Display(Name = "Mã nhân viên")]
        public int ID { get; set; }
        [Display(Name = "Họ Tên")]
        public string Name { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Tỉnh thành")]
        public string City { get; set; }

        public Employee(int iD, string name, string gender, string city)
        {
            ID = iD;
            Name = name;
            Gender = gender;
            City = city;
        }
    }
}