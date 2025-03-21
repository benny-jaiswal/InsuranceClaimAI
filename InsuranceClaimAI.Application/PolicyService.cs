using InsuranceClaimAI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAI.Application
{
    public class PolicyService : IPolicyService
    {
        // Simulating fetching policy data by policy number. Returning demo data.
        public async Task<Policy> GetPolicyDetailsAsync(string policyNumber)
        {
            // Simulating async data fetching
            await Task.Delay(500);  // Simulate delay for async operation

            // Returning demo data based on policy number
            if (policyNumber == "POL1234567890")
            {
                return new Policy
                {
                    PolicyNumber = "POL1234567890",
                    PolicyholderName = "John Doe",
                    VehicleModel = "Toyota Corolla",
                    VehicleRegistrationNumber = "ABC123",
                    CoverageType = "Collision",
                    PolicyLimit = 5000,
                    Deductible = 500,
                    StartDate = new DateTime(2022, 1, 1),
                    EndDate = new DateTime(2023, 12, 31),
                    Status = "Active",
                    Insurer = "XYZ Insurance",
                    PolicyholderAddress = "123 Elm Street, Springfield",
                    ContactNumber = "+1234567890",
                    Email = "johndoe@example.com",
                    Conditions = new List<string>
                {
                    "No claims for unauthorized drivers",
                    "Claims must be reported within 24 hours of the incident"
                },
                    ClaimHistory = new List<Claim>
                {
                    new Claim
                    {
                        ClaimId = "12345",
                        ClaimAmount = 1500,
                        ClaimStatus = "Approved",
                        ClaimDate = new DateTime(2023, 3, 1),
                        DamageDescription = "Front bumper collision"
                    }
                }
                };
            }
            else if (policyNumber == "POL9876543210")
            {
                return new Policy
                {
                    PolicyNumber = "POL9876543210",
                    PolicyholderName = "Jane Smith",
                    VehicleModel = "Honda Civic",
                    VehicleRegistrationNumber = "XYZ789",
                    CoverageType = "Comprehensive",
                    PolicyLimit = 10000,
                    Deductible = 1000,
                    StartDate = new DateTime(2021, 5, 15),
                    EndDate = new DateTime(2023, 5, 15),
                    Status = "Expired",
                    Insurer = "ABC Insurance",
                    PolicyholderAddress = "456 Oak Avenue, Downtown",
                    ContactNumber = "+1987654321",
                    Email = "janesmith@example.com",
                    Conditions = new List<string>
                {
                    "Claims exceeding $5000 require additional documentation",
                    "Policy does not cover theft outside the home address"
                },
                    ClaimHistory = new List<Claim>
                {
                    new Claim
                    {
                        ClaimId = "67890",
                        ClaimAmount = 3000,
                        ClaimStatus = "Rejected",
                        ClaimDate = new DateTime(2022, 6, 10),
                        DamageDescription = "Side door damage from collision"
                    }
                }
                };
            }
            else
            {
                return null;  // If no policy matches the number, return null
            }
        }
    }
}
