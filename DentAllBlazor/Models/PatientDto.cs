﻿
namespace DentAllBlazor.Models
{
    public class PatientDto
    {
        
        public string FirstName { get; set; } = "";
     
        public string LastName { get; set; } = "";
        
        public string Email { get; set; } = "";
        
        public string Phone { get; set; } = "";
        
        public string Address { get; set; } = "";
    
        public string Status { get; set; } = "";

        public DateTime CreatedAt { get; set; }
        public PatientDto() { }
    }
}
