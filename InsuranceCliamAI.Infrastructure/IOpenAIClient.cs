using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAI.Infrastructure
{
    // Define the IOpenAIClient interface
    public interface IOpenAIClient
    {
        Task<string> GenerateTextAsync(string prompt);
    }

}
