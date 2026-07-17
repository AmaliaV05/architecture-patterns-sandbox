using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StatusCheckSystem.BusinessLayer.Interfaces;
using StatusCheckSystem.DTOs;

namespace ArchitecturePatternsSandbox.WebApi.Controllers.StatusCheckSystem
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("StatusCheckSystem")]
    public class VerificationController : ControllerBase
    {
        private readonly IVerificationService _verificationService;
        private readonly IMapper _mapper;

        public VerificationController(IVerificationService verificationService, IMapper mapper)
        {
            _verificationService = verificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var verifications = await _verificationService.CheckStatus();
            var verificationsDto = _mapper.Map<IList<VerificationDto>>(verifications);

            return Ok(verificationsDto);
        }
    }
}
