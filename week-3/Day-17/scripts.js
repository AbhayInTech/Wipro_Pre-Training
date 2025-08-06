// Step 1: Add event listener for form submission
document
  .getElementById("admissionForm")
  .addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission

    // Step 2: Retrieve and trim input values
    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const phone = document.getElementById("phone").value.trim();
    const course = document.getElementById("courses").value;

    // Step 3: Validate inputs
    let isValid = true;

    if (!name || !email || !phone) {
      alert("Please fill in all fields.");
      isValid = false;
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email)) {
      alert("Please enter a valid email address.");
      isValid = false;
    } else if (!/^\d{10}$/.test(phone)) {
      alert("Please enter a valid 10-digit phone number.");
      isValid = false;
    }

    // Step 4: Display confirmation and submitted data
    if (isValid) {
      alert(
        `Thank you ${name}, your application for ${course} has been submitted successfully!`
      );
      document.getElementById("result").style.display = "block";
      document.getElementById("submittedName").textContent = `Name: ${name}`;
      document.getElementById("submittedEmail").textContent = `Email: ${email}`;
      document.getElementById("submittedPhone").textContent = `Phone: ${phone}`;
      document.getElementById(
        "submittedCourse"
      ).textContent = `Course: ${course}`;
    }
  });
