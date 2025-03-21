using InsuranceClaimAI.Core;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceClaimAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimDecisionService _claimDecisionService;

        public ClaimsController(IClaimDecisionService claimDecisionService)
        {
            _claimDecisionService = claimDecisionService;
        }

        [HttpPost("decide")]
        public async Task<IActionResult> DecideClaim([FromBody] Claim claim)
        {
            var decision = await _claimDecisionService.DecideClaimAsync(claim);
            return Ok(new { Decision = decision });
        }
    }

}
