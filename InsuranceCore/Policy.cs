using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAI.Core
{
    // Policy.cs (Domain Model)
    public class Policy
    {
        // Basic Information about the Policy
        public string PolicyNumber { get; set; }
        public string PolicyholderName { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string CoverageType { get; set; }  // e.g., "Collision", "Comprehensive", etc.
        public double PolicyLimit { get; set; }  // The maximum coverage amount
        public double Deductible { get; set; }  // The deductible amount for the claim
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }  // e.g., "Active", "Expired", etc.

        // Add other relevant fields for your insurance policy
        public string Insurer { get; set; }
        public string PolicyholderAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        // Policy Conditions (Optional)
        public List<string> Conditions { get; set; }

        // Claim History (Optional)
        public List<Claim> ClaimHistory { get; set; }

        // Constructor
        public Policy()
        {
            Conditions = new List<string>();
            ClaimHistory = new List<Claim>();
        }
    }

}
