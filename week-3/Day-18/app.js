// step 1: Define async getuser() function
async function getUser() {
  const userDiv = document.getElementById("userInfo");
  var userId = document.getElementById("userId").value;
  var link = `https://jsonplaceholder.typicode.com/users/${userId}`;
  userDiv.innerHTML = "<span>User Data from API is Loading...<span>";
  try {
    // step 2: Fetch data asynchronously from the API
    const response = await fetch(link);
    // step 3: Handle errors using try-catch block
    if (!response.ok) {
      throw new Error("Network response was not ok");
    }
    // step 4: check if the response is ok
    const user = await response.json();
    // step 5: convert the response to JSON
    userDiv.innerHTML = `
            <h2>User Details</h2>
            <p><strong>ID:</strong> ${user.id}</p>
            <p><strong>Username:</strong> ${user.username}</p>   
            <p><strong>Name:</strong> ${user.name}</p>
            <p><strong>Email:</strong> ${user.email}</p>
            <p><strong>Phone:</strong> ${user.phone}</p>
            <p><strong>Website:</strong> ${user.website}</p>
            <p><strong>Company:</strong> ${user.company.name}</p>
            <p><strong>Address:</strong> ${user.address.street}, ${user.address.city}, ${user.address.zipcode}</p>
        `;
    // step 6: update the UI with the fetched data
  } catch (error) {
    userDiv.innerHTML = `<p style="color:red;">Error fetching user data: ${error.message}</p>`;
  }
}
// step 2: Fetch data asynchronously from the API
// step 3: Handle errors using try-catch block
// step 4: check if the response is ok
// step 5: convert the response to JSON
// step 6: update the UI with the fetched data
