function calc() {
  // step 1: Get the input values
  // step 2: Validate the inputs
  // step 3: Perform the calculation based on the selected operation
  // step 4: Display the result
  const num1 = parseFloat(document.getElementById("num1").value);
  const num2 = parseFloat(document.getElementById("num2").value);
  const operation = document.getElementById("operation").value;
  let result;

  if (isNaN(num1) || isNaN(num2)) {
    document.getElementById("result").value = "";
    document.getElementById("error").innerText = "Please enter valid numbers.";
    return;
  }

  switch (operation) {
    case "add":
      result = num1 + num2;
      break;
    case "subtract":
      result = num1 - num2;
      break;
    case "multiply":
      result = num1 * num2;
      break;
    case "divide":
      if (num2 === 0) {
        document.getElementById("result").value = "";
        document.getElementById("error").innerText = "Cannot divide by zero.";
        return;
      }
      result = num1 / num2;
      break;
    default:
      document.getElementById("result").value = "";
      document.getElementById("error").innerText =
        "Invalid operation selected.";
      return;
  }

  document.getElementById("result").value = result;
  document.getElementById("error").innerText = "";
}

function clr() {
  document.getElementById("num1").value = "";
  document.getElementById("num2").value = "";
  document.getElementById("operation").value = "add";
  document.getElementById("result").value = "";
}
