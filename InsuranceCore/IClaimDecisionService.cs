using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAI.Core
{
    public interface IClaimDecisionService
    {
        Task<string> DecideClaimAsync(Claim claim);
    }
}
