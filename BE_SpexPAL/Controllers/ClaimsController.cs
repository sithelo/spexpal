using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using BE_SpexPAL.DataContext;
using BE_SpexPAL.Infrastructure;
using BE_SpexPAL.Models;
using BE_SpexPAL.Repository;

namespace BE_SpexPAL.Controllers
{
     [RoutePrefix("api/claims")]
    public class ClaimsController : BaseApiController
    {
        SpexPalRepository<IdentityUserClaimsList> _repo = new SpexPalRepository<IdentityUserClaimsList>(new SpexPalDbContext());

        //Add Claims to table Claims in SpexPalData
        [Route("add")]
        public async Task<IHttpActionResult> AddClaimsToSpexpalTable(IdentityUserClaimsList model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           await _repo.AddAsync(model);
           Uri locationHeader = new Uri(Url.Link("GetClaim", new { id = model.Id }));
            return Created(locationHeader, model);
        }
         //getbyId
        [Route("GetClaim", Name = "GetClaim")]
        public async Task<IHttpActionResult> GetClaim(Guid id)
        {
            var userclaim = await _repo.GetById(id);

            if (userclaim != null)
            {
                return Ok(userclaim);
            }

            return NotFound();

        }
        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/assignclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignClaimsToUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToAssign)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            foreach (ClaimBindingModel claimModel in claimsToAssign)
            {
                if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
                {

                    await this.AppUserManager.RemoveClaimAsync(id, new Claim(claimModel.Type, claimModel.Value, ClaimValueTypes.String));
                }

                await this.AppUserManager.AddClaimAsync(id, new Claim(claimModel.Type, claimModel.Value, ClaimValueTypes.String));
            }

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/removeclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> RemoveClaimsFromUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToRemove)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            foreach (ClaimBindingModel claimModel in claimsToRemove)
            {
                if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
                {
                    await this.AppUserManager.RemoveClaimAsync(id, new Claim(claimModel.Type, claimModel.Value, ClaimValueTypes.String));
                }
            }

            return Ok();
        }

    }
}
