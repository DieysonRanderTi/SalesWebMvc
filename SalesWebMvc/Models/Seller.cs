using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="O Nome deve ser preenchido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres.")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Salário Base")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }

        [Display(Name = "Data de Aniversário")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }

        [Display(Name = "Departamento")]
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sales => sales.Date >= initial && sales.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
