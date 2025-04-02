document.getElementById('paymentForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    // Collect form data
    const studentId = document.getElementById('studentId').value;
    const service = document.getElementById('service').value;
    const amount = document.getElementById('amount').value;
    const name = document.getElementById('name').value;
    const email = document.getElementById('email').value;
    const cardNumber = document.getElementById('cardNumber').value;
    const expiry = document.getElementById('expiry').value;
    const cvv = document.getElementById('cvv').value;

    // Basic input validation
    if (!studentId || !service || !amount || !name || !email || !cardNumber || !expiry || !cvv) {
        document.getElementById('message').className = 'error-message';
        document.getElementById('message').textContent = 'Please fill in all fields.';
        return;
    }

    // Create a payload
    const paymentData = {
        studentId,
        service,
        amount,
        name,
        email,
        cardNumber,
        expiry,
        cvv
    };

    try {
        // Send data to the server
        const response = await fetch('https://localhost:5001/api/payment', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(paymentData)
        });

        const result = await response.json();

        if (response.ok) {
            document.getElementById('message').textContent = 'Payment Successful!';
        } else if (response.status === 400) {
            document.getElementById('message').className = 'error-message';
            document.getElementById('message').textContent = result.error || 'Invalid request!';
        } else if (response.status === 500) {
            document.getElementById('message').className = 'error-message';
            document.getElementById('message').textContent = 'Server error occurred!';
        } else {
            document.getElementById('message').className = 'error-message';
            document.getElementById('message').textContent = 'Payment Failed!';
        }
    } catch (error) {
        console.error('Error processing payment:', error);
        document.getElementById('message').className = 'error-message';
        document.getElementById('message').textContent = 'An error occurred while processing your payment.';
    }
});
