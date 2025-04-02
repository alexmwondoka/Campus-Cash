using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitalServicePaymentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        // Simulated list of valid Student/Staff IDs
        private static readonly List<string> ValidIds = new List<string>
        {
            "STU12345", "STU67890", "STA112233", "STA445566" // Add valid IDs here
        };

        [HttpPost]
        public IActionResult ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            // Validate Student/Staff ID
            if (!ValidIds.Contains(paymentRequest.StudentId))
            {
                return BadRequest(new { error = "Invalid Student/Staff ID. Access denied." });
            }

            // Validate other inputs
            if (string.IsNullOrEmpty(paymentRequest.Name) ||
                string.IsNullOrEmpty(paymentRequest.Email) ||
                string.IsNullOrEmpty(paymentRequest.CardNumber) ||
                string.IsNullOrEmpty(paymentRequest.Expiry) ||
                string.IsNullOrEmpty(paymentRequest.CVV))
            {
                return BadRequest(new { error = "Invalid payment details. Please fill all fields." });
            }

            // Simulate successful payment processing
            return Ok(new { message = "Payment processed successfully for " + paymentRequest.Service + "!" });
        }
        
        
    }
    
}