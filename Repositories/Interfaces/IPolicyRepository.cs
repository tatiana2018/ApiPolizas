using Microsoft.AspNetCore.Mvc;
using Poliza.Models;

namespace Poliza.Repositories.Interfaces
{
    public interface IPolicyRepository
    {

        Task<IEnumerable<PolicyEntity>> GetPoliciesItems();
        Task<PolicyEntity> GetPolicy(long id);
        Task PutPolicy(PolicyEntity policy);
        Task PostPolicy(PolicyEntity policy);
        Task DeletePolicy(long id);
        Boolean PolicyExists(long id);
        Task<PolicyEntity> GetPolicyByParam(string param);

    }
}
