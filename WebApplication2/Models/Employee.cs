using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Table("Employees",Schema ="HR")]
    public class Employee
    {
        [Key]
        [Display(Name ="ID")]
        public int EmployeeID { set; get; }
        [Display(Name ="Employee Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string EmplyeeName { set; get; }
        [Display(Name = "User Image")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string ImageUser { set; get; } = string.Empty;

        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { set; get; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { set; get; }

        [Display(Name ="Salary")]
        [Column(TypeName = "DECIMAL")]
        public decimal Salary { set; get; }

        [Display(Name ="National Id")]
        [Required]
        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(14)]
        public string NationalID { set; get; }

        public int DepartmentId { set; get; }

        [ForeignKey("DepartmentId")]

        public Department Department { set; get; }
    }
}