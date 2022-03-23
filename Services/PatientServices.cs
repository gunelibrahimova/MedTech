using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PatientServices
    {
        private readonly MedTechDbContext _context;

        public PatientServices(MedTechDbContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            return _context.patients.ToList();
        }

        public void Create(Patient patient)
        {
            _context.Add(patient);
            _context.SaveChanges();
        }

        public Patient GetById(int id)
        {
            return _context.patients.FirstOrDefault(x => x.Id == id);
        }

        public void EditPatient(Patient patient, string PhotoURL)
        {
            patient.PhotoURL = PhotoURL;
            var updateEntry = _context.Entry(patient);
            updateEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Patient Detail(int id)
        {
            return _context.patients.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var patient = _context.patients.Find(id);
            _context.Remove(patient);
            _context.SaveChanges();
        }

    }
}
