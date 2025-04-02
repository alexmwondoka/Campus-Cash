namespace DigitalServicePaymentSystem
{
    public class PaymentRequest
    {
        public required string StudentId { get; set; } // Student/Staff ID
        public required string Service { get; set; }  // Selected service
        public required string Amount { get; set; }   // Payment amount
        public required string Name { get; set; }     // User's name
        public required string Email { get; set; }    // User's email
        public required string CardNumber { get; set; } // Card number
        public required string Expiry { get; set; }   // Expiry date (MM/YYYY)
        public required string CVV { get; set; }      // Card CVV
    }
}