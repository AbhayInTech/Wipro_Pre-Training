// Using fetch with .then() and .catch() methods
function getUser() {
  const userDiv = document.getElementById("userInfo");
  var userId = document.getElementById("userId").value;
  var link = `https://jsonplaceholder.typicode.com/users/${userId}`;
  userDiv.innerHTML =
    "<span>Via Promises User Data from API is Loading...<span>";
  fetch(link)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok....");
      }
      return response.json();
    })
    .then((user) => {
      userDiv.innerHTML = `
                <h2>User Details</h2>
                <p><strong>ID:</strong> ${user.id}</p>
                <p><strong>Username:</strong> ${user.username}</p>   
                <p><strong>Name:</strong> ${user.name}</p>
                <p><strong>Email:</strong> ${user.email}</p>
                <p><strong>Phone:</strong> ${user.phone}</p>
            `;
    })
    .catch((error) => {
      userDiv.innerHTML = `<p style="color:red;">Error fetching user data: ${error.message}</p>`;
    });
}
