using KaasService.Models;
using KaasService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaasService.Controllers
{
    [Route("kazen")]
    [ApiController]
    public class KazenController : ControllerBase
    {
        private readonly IKazenRepository repository;
        public KazenController(IKazenRepository repository) => this.repository = repository;

        [HttpGet]
        public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(int id)
        {
            var kaas = await repository.FindByIdAsync(id);
            return kaas == null ? base.NotFound() : base.Ok(kaas);
        }

        [HttpGet("smaken")]
        public async Task<ActionResult> FindBySmaak(string smaak) =>
         base.Ok(await repository.FindBySmaakAsync(smaak));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, kazen kaas)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    kaas.id = id;
                    await repository.UpdateAsync(kaas);
                    return base.Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return base.NotFound();
                }
                catch
                {
                    return base.Problem();
                }
            }
            return base.BadRequest(this.ModelState);
        }


    
        [HttpPost]
        public async Task<ActionResult> Post(kazen kaas)
        {
            if (this.ModelState.IsValid)
            {
                await repository.InsertAsync(kaas);
                return base.CreatedAtAction(nameof(FindById), new
                {
                    id = kaas.id
                }, null);

            }
            return base.BadRequest(this.ModelState);


        }
        [HttpPost("update")]
        public async Task<ActionResult> UpdateArtist([FromBody] kazen kaas)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await repository.UpdateAsync(kaas);
                    return base.Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return base.NotFound();
                }
                catch
                {
                    return base.Problem();
                }
            }
            return base.BadRequest();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var kaas = await repository.FindByIdAsync(id);
            if (kaas == null)
            {
                return base.NotFound();
            }
            await repository.DeleteAsync(kaas);
            return base.Ok();
        }
    }
}
