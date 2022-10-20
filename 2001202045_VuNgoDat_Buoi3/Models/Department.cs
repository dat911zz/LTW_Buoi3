using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2001202045_VuNgoDat_Buoi3.Models
{
    public class Department
    {
        [Display(Name = "Mã Phòng Ban")]
        public int Id { get; set; }
        [Display(Name = "Tên Phòng Ban")]
        public string Name { get; set; }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}