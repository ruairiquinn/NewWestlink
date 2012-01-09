using System;
using System.ComponentModel.DataAnnotations;
using Core.Enumerations;
using Core.Interfaces;

namespace NewWestlink.Models
{
    public class Client : IClient
    {        
        public string Id { get; set; }

        [Required]
        [Display(Name = "Client Forname")]
        public string Forename { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "IsEmployed")]
        public bool IsEmployed { get; set; }

        [Display(Name = "Gender")]
        public Enumerations.Gender? Gender { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}