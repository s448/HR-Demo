using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Departments",Schema ="HR")]
    public class Department
    {
        [Key]
        [Display(Name ="ID")]
        public int DepartmentID{set; get; }
        [Required]
        [Display(Name = "Department Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string DepartmentName { set; get; } = string.Empty;
    }
}