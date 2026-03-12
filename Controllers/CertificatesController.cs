using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Certifind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private static List<string> certificates = new List<string>();

        // GET: api/certificates
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCertificates()
        {
            return Ok(certificates);
        }

        // POST: api/certificates
        [HttpPost]
        public ActionResult AddCertificate([FromBody] string certificate)
        {
            certificates.Add(certificate);
            return CreatedAtAction(nameof(GetCertificates), new { id = certificates.Count - 1 }, certificate);
        }

        // DELETE: api/certificates/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCertificate(int id)
        {
            if (id < 0 || id >= certificates.Count)
                return NotFound();

            certificates.RemoveAt(id);
            return NoContent();
        }
    }
}