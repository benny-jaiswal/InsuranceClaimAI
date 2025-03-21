using InsuranceClaimAI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAI.Application
{
    public class ClaimHistoryService : IClaimHistoryService
    {
        // Simulating fetching claim history by policy number. Returning demo data.
        public async Task<IEnumerable<Claim>> GetClaimHistoryAsync(string policyNumber)
        {
            // Simulate async data fetching with Task.Delay
            await Task.Delay(500);  // Simulate delay for async operation

            // Return demo data based on policy number
            if (policyNumber == "POL1234567890")
            {
                return new List<Claim>
            {
                new Claim
                {
                    ClaimId = "12345",
                    ClaimAmount = 1500,
                    ClaimStatus = "Approved",
                    ClaimDate = new DateTime(2023, 3, 1),
                    DamageDescription = "Front bumper collision"
                },
                new Claim
                {
                    ClaimId = "12346",
                    ClaimAmount = 2000,
                    ClaimStatus = "Approved",
                    ClaimDate = new DateTime(2022, 8, 15),
                    DamageDescription = "Side door scratch"
                }
            };
            }
            else if (policyNumber == "POL9876543210")
            {
                return new List<Claim>
            {
                new Claim
                {
                    ClaimId = "67890",
                    ClaimAmount = 3500,
                    ClaimStatus = "Rejected",
                    ClaimDate = new DateTime(2022, 6, 10),
                    DamageDescription = "Side swipe collision"
                }
            };
            }
            else
            {
                return new List<Claim>();  // Return empty list if no claims found for the policy number
            }
        }
    }
}
