using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poliza.Models;
using Poliza.Repositories;
using Poliza.Repositories.Interfaces;

namespace Poliza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {

        private readonly IPolicyRepository _policyRespository;

        public PolicyController(PolicyRepository policyRespository)
        {
            _policyRespository = policyRespository;
        }



        // GET: api/Policy
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyEntity>>> GetPoliciesItems()
        {

            try
            {
                var policies = await _policyRespository.GetPoliciesItems();
                if (policies == null)
                {
                    return NotFound();
                }

                return Ok(policies);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error obteniendo las polizas:{ex.Message}");
            }


        }

        // GET: api/Policy/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<PolicyEntity>> GetPolicy(long id)
        {
            try
            {
                var policy = await _policyRespository.GetPolicy(id);
                if (policy == null)
                {
                    return NotFound();
                }

                return Ok(policy);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error obteniendo las polizas: {ex.Message}");
            }
        }

        // PUT: api/Policy/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPolicy(long id,PolicyEntity policy)
        {
            try
            {
                if (id != policy.ID)
                {
                    return BadRequest();
                }
                await _policyRespository.PutPolicy(policy);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_policyRespository.PolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error actualizando la poliza: {ex.Message}");
            }
        }

        // POST: api/Policy
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PolicyEntity>> PostPolicy(PolicyEntity policy)
        {

            try
            {
                if (!ActivePolicy(policy.PolicyEndDate))
                {
                    throw new InvalidOperationException("La poliza no esta vigente");
                }
                await _policyRespository.PostPolicy(policy);
                return CreatedAtAction(nameof(GetPolicy), new { id = policy.ID }, policy);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creando la poliza: {ex.Message}");
            }
        }

        // DELETE: api/Policy/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePolicy(long id)
        {
            try
            {
                var policy = await _policyRespository.GetPolicy(id);
                if (policy == null)
                {
                    return NotFound();
                }
                await _policyRespository.DeletePolicy(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting policy: {ex.Message} ");
            }
        }

        // GET: api/byId/5
        [HttpGet("byId/{param}")]
        [Authorize]
        public async Task<ActionResult<PolicyEntity>> GetPolicyByParam(string param)
        {
            try
            {
                var policy = await _policyRespository.GetPolicyByParam(param);
                if (policy == null)
                {
                    return NotFound();
                }

                return Ok(policy);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error obteniendo las polizas: {ex.Message}");
            }
        }

        private bool ActivePolicy(DateTime policyEndDate)
        {
            if (policyEndDate < DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
