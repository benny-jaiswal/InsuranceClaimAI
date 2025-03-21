
namespace InsuranceClaimAI.Core
{
    // Models
    public class Claim
    {
        public DateTime ClaimDate;

        public string ClaimId { get; set; }
        public string ClaimantName { get; set; }
        public string VehicleModel { get; set; }
        public double ClaimAmount { get; set; }
        public string DamageDescription { get; set; }
        public string AccidentDate { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyCoverage { get; set; }
        public string ClaimStatus { get; set; }
    }
}
