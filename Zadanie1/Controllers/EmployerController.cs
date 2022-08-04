using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Zadanie1.Data;
using Zadanie1.Dtos;
using Zadanie1.Models;

namespace Zadanie1.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SearchByNip(NipRequest nipRequestDto)
        {
            var employer = new Employer();
            try
            {
                HttpClient client = new HttpClient();
                AddClientHeaders(client);
                HttpResponseMessage response = client.GetAsync($@"https://wl-api.mf.gov.pl/api/search/nip/{nipRequestDto.NIP}?date=2020-01-01").Result;
                var employerInformationsResponse = response.Content.ReadAsStringAsync().Result;

                var employerInformation = JsonSerializer.Deserialize<EmployerResult>(employerInformationsResponse);
                if (employerInformation.result != null)
                {
                    employer.Id = Guid.NewGuid().ToString();
                    employer.ResidenceAddress = employerInformation.result.subject.residenceAddress;
                    employer.Name = employerInformation.result.subject.name;
                    employer.Nip = employerInformation.result.subject.nip;
                    employer.StatusVat = employerInformation.result.subject.statusVat;
                    employer.Regon = employerInformation.result.subject.regon;
                    employer.RegistrationLegalDate = employerInformation.result.subject.registrationLegalDate;
                    
                    _dbContext.Employers.Add(employer);
                    _dbContext.SaveChanges();
                }

            }
            catch
            {
                return View(employer);
            }


            return View(employer);
        }

        private void AddClientHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
