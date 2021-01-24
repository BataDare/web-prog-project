using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PROJEKAT.models;

namespace PROJEKAT.controller
{

    [ApiController]
    [Route("[controller]")]
    public class ProdavnicaController : ControllerBase
    {
        public prodavnicaContext c { get; set; }

        public ProdavnicaController(prodavnicaContext pc)
        {
            c = pc;
        }

        [Route("PreuzmiProdavnice")]
        [HttpGet]
        public async Task<JsonResult> PreuzmiProdavnice()
        {
            var p = await c.Prodavnice.Include(p => p.Proizvodi).ToListAsync();
            return new JsonResult(p);
        }

        [Route("PreuzmiDobavljace")]
        [HttpGet]
        public async Task<JsonResult> PreuzmiDobavljace()
        {
            var p = await c.Dobavljaci.Include(p => p.Proizvodi).ToListAsync();
            return new JsonResult(p);
        }

        [Route("DodajProdavnicu")]
        [HttpPost]
        public async Task DodajProdavnicu(Prodavnica prodavnica)
        {
            c.Prodavnice.Add(prodavnica);
            await c.SaveChangesAsync();
        }

        [Route("BrisiProdavnicu/{id}")]
        [HttpDelete]
        public async Task BrisiProdavnicu(int id)
        {
            var p = await c.Prodavnice.FindAsync(id);
            c.Prodavnice.Remove(p);
            await c.SaveChangesAsync();
        }

        [Route("DodajProizvod/{idProd}/{idDob}")]
        [HttpPost]
        public async Task DodajProizvod(Proizvod proizvod, int idP, int idD)
        {
            var prod1 = await c.Prodavnice.FindAsync(idP);
            proizvod.Prodavnica = prod1;
            var prod2 = await c.Dobavljaci.FindAsync(idD);
            proizvod.Dobavljac = prod2;
            
            c.Proizvodi.Add(proizvod);
            await c.SaveChangesAsync();
        }

        [Route("BrisiProizvod/{id}")]
        [HttpDelete]
        public async Task BrisiProizvod(int id)
        {
            var p = await c.Proizvodi.FindAsync(id);
            c.Proizvodi.Remove(p);
            await c.SaveChangesAsync();
        }

        [Route("BrisiDobavljaca/{id}")]
        [HttpDelete]
        public async Task BrisiDobavljaca(int id)
        {
            var p = await c.Dobavljaci.FindAsync(id);
            c.Dobavljaci.Remove(p);
            await c.SaveChangesAsync();
        }

        [Route("Izmeni/{id}/{novaKolicina}")]
        [HttpPut]
        public async Task Izmeni(int id, int novaKolicina)
        {
            var p = await c.Proizvodi.FindAsync(id);
            p.Kolicina = novaKolicina;
            c.Proizvodi.Update(p);
            await c.SaveChangesAsync();
        }

        [Route("DodajDobavljaca")]
        [HttpPost]
        public async Task DodajDobavljaca(Dobavljac dobavljac)
        {
            c.Dobavljaci.Add(dobavljac);
            await c.SaveChangesAsync();
        }

        [Route("IzmeniDobavljaca/{id}/{noviRejting}")]
        [HttpPut]
        public async Task IzmeniDobavljaca(int id, float noviRejting)
        {
            var p = await c.Dobavljaci.FindAsync(id);
            p.Rating = noviRejting;
            c.Dobavljaci.Update(p);
            await c.SaveChangesAsync();
        }
    }

}