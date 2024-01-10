using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Digitize.Server.Interface;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Digitize.Shared.Data;

namespace Digitize.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyDigitizeController : ControllerBase
    {

        private readonly IDigitizeInterface _digitizeinterface;
        public MyDigitizeController(IDigitizeInterface digitizeinterface)
        {
            _digitizeinterface = digitizeinterface;
        }

        [HttpPost("AddAdhaar")]
        public async Task<IActionResult> AddAdhaar([FromBody] Aadhaar aadhaarData)
        {
            try
            {
                var result = await _digitizeinterface.CreateAdhaar(aadhaarData);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddVoter")]
        public async Task<IActionResult> AddVoter([FromBody] Voter voterData)
        {
            try
            {
                var result = await _digitizeinterface.CreateVoter(voterData);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("SelectAllAadhaar")]
        public async Task<IActionResult> SelectAllAadhaar()
        {
            try
            {
                var result = await _digitizeinterface.GetAllAdhaar();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet("SelectAadhaar/{Uid}")]
        public async Task<IActionResult> SelectAadhaar(int Uid)
        {
            try
            {
                var result = await _digitizeinterface.GetAdhaar(Uid);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("SelectVoter/{id}")]
        public async Task<IActionResult> SelectVoter(int id)
        {
            try
            {
                var result = await _digitizeinterface.GetVoter(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet("SelectBirth/{id}")]
        public async Task<IActionResult> SelectBirth(int id)
        {
            try
            {
                var result = await _digitizeinterface.GetBirth(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpDelete("RemoveVoter/{id}")]
        public async Task<IActionResult> RemoveVoter(int id)
        {
            try
            {
                var result = await _digitizeinterface.RemoveVoter(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet("RemoveBirth/{id}")]
        public async Task<IActionResult> RemoveBirth(int id)
        {
            try
            {
                var result = await _digitizeinterface.RemoveBirth(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet("RemoveAadhaar/{Uid}")]
        public async Task<IActionResult> RemoveAadhaar(int Uid)
        {
            try
            {
                var result = await _digitizeinterface.RemoveAdhaar(Uid);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost("AddBirth")]
        public async Task<IActionResult> AddBirth([FromBody] Birth birthData)
        {
            try
            {
                var result = await _digitizeinterface.CreateBirth(birthData);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
