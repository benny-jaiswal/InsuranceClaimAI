using InsuranceClaimAI.Core;
using InsuranceClaimAI.Infrastructure;
using Newtonsoft.Json;

namespace InsuranceClaimAI.Application
{
    public class ClaimDecisionService : IClaimDecisionService
    {
        private readonly IPolicyService _policyService;
        private readonly IClaimHistoryService _claimHistoryService;
        private readonly IOpenAIClient _openAIClient;

        public ClaimDecisionService(IPolicyService policyService, IClaimHistoryService claimHistoryService, IOpenAIClient openAIClient)
        {
            _policyService = policyService;
            _claimHistoryService = claimHistoryService;
            _openAIClient = openAIClient;
        }

        public async Task<string> DecideClaimAsync(Core.Claim claim)
        {
            // Retrieve policy data and claim history
            var policy = await _policyService.GetPolicyDetailsAsync(claim.PolicyNumber);
            var claimHistory = await _claimHistoryService.GetClaimHistoryAsync(claim.PolicyNumber);

            // Prepare the prompt for GPT-4 decision-making
            var prompt = $"Claim details: {claim.ClaimantName} has submitted a claim for {claim.DamageDescription}. The policy coverage is {policy.CoverageType} with a deductible of {policy.Deductible}. The claim amount is {claim.ClaimAmount}. Please make a decision based on the provided information and the claim history: {JsonConvert.SerializeObject(claimHistory)}";

            // Call GPT-4 to generate decision
            var decision = await _openAIClient.GenerateTextAsync(prompt);

            // Return decision
            return decision;
        }
    }

}
