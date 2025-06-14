using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PatientController(ApplicationDbContext context) {
            this._context = context;
        }

        [HttpGet]
        public List<Patient> GetPatient() {
            return _context.Patients.OrderBy(x => x.Id).ToList();
        }

        [HttpGet("{Id}")]
        public IActionResult GetPatientById(int Id) {
            var patient = _context.Patients.Find(Id);
            if (patient == null) {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientDto patientdto) {

            var otherPatient = _context.Patients.FirstOrDefault(x => x.Email == patientdto.Email);
            if (otherPatient != null)
            {
                return BadRequest("Patient already Exists");
            }

            Patient newPatient = new Patient
            {
                FirstName = patientdto.FirstName,
                LastName = patientdto.LastName,
                Email = patientdto.Email,
                Phone = patientdto.Phone,
                Address = patientdto.Address,
                Status = patientdto.Status,
                CreatedAt = DateTime.Now
            };

            _context.Patients.Add(newPatient);
            _context.SaveChanges();
            return Ok(newPatient);
        }

        [HttpPut("{Id}")]
        public IActionResult EditPatient(int Id, PatientDto patientdto) {

            var otherPatient = _context.Patients.FirstOrDefault(x => x.Email == patientdto.Email && x.Id != Id);
            if (otherPatient != null) {
                ModelState.AddModelError("Email", "Email is already used");
                var validate = ModelState;
                return BadRequest(ModelState);
            }

            var patient = _context.Patients.Find(Id);   
            if (patient == null) {
                return NotFound();
            }

            patient.FirstName = patientdto.FirstName;
            patient.LastName = patientdto.LastName;
            patient.Email = patientdto.Email;
            patient.Phone = patientdto.Phone;
            patient.Address = patientdto.Address;
            patient.Status = patientdto.Status;

            _context.SaveChanges();
            return Ok(patient);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletePatient(int Id) {
            var patient = _context.Patients.Find(Id);
            if (patient == null) {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return Ok(patient);
        }
    }
}
