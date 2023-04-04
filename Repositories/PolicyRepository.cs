using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Poliza.Models;
using Poliza.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;


namespace Poliza.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly PolicyContextEntity _context;

        public PolicyRepository(PolicyContextEntity context)
        {
            _context = context;
        }

        public PolicyRepository()
        {
        }

        public async Task DeletePolicy(long id)
        {
            try
            {
                var policy = await GetPolicy(id);
                _context.PoliciesItems.Remove(policy);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<IEnumerable<PolicyEntity>> GetPoliciesItems()
        {
            try
            {
    
                if (_context.PoliciesItems == null)
                {
                    throw new InvalidOperationException("No se puede obtener el listado por que el contexto esta nulo");
                }

                return await _context.PoliciesItems.ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }

        public async Task<PolicyEntity> GetPolicy(long id)
        {

            try
            {
                return await _context.PoliciesItems.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PostPolicy(PolicyEntity policy)
        {
            try
            {
                _context.PoliciesItems.Add(policy);
                 await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task PutPolicy(PolicyEntity policy)
        {

            try
            {
                _context.Entry(policy).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PolicyExists(long id)
        {
            try
            {
                return (_context.PoliciesItems?.Any(e => e.ID == id)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PolicyEntity> GetPolicyByParam(string param)
        {
            try
            {
                if (int.TryParse(param, out int policyNumber))
                {
                    // param es un número entero válido, buscar por PolicyNumber
                    return await _context.PoliciesItems.SingleOrDefaultAsync(p => p.PolicyNumber == policyNumber);
                }
                else
                {
                    // param no es un número entero válido, buscar por VehiclePlate
                    return await _context.PoliciesItems.SingleOrDefaultAsync(p => p.VehiclePlate == param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
