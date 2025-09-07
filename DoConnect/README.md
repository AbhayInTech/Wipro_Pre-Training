# DoConnect

DoConnect is a full-stack application built with .NET Core for the backend and Angular for the frontend. It includes features for user authentication, role-based access, and real-time notifications using SignalR.

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (version 18 or higher) and npm
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database
- [Angular CLI](https://angular.dev/tools/cli) (install globally with `npm install -g @angular/cli`)

## Project Structure

- `DoConnectBackend/`: .NET Core Web API backend
- `DoConnectFrontend/`: Angular frontend application
- `TestApp.Tests/`: Unit tests for the backend

## Backend Setup

1. Navigate to the backend directory:

   ```bash
   cd DoConnectBackend
   ```

2. Restore NuGet packages:

   ```bash
   dotnet restore
   ```

3. Update the database connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your-server;Database=DoConnectDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. Run database migrations to create the database schema:

   ```bash
   dotnet ef database update
   ```

5. Start the backend server:

   ```bash
   dotnet run
   ```

   The backend will run on `https://localhost:5001` (or `http://localhost:5000` if HTTPS is disabled). You can access the Swagger UI at `https://localhost:5001/swagger`.

## Frontend Setup

1. Navigate to the frontend directory:

   ```bash
   cd DoConnectFrontend
   ```

2. Install npm dependencies:

   ```bash
   npm install
   ```

3. Start the Angular development server:

   ```bash
   npm start
   ```

   The frontend will run on `http://localhost:4200`.

## Running the Application

1. Ensure the backend is running (step 5 above).
2. Ensure the frontend is running (step 3 above).
3. Open your browser and navigate to `http://localhost:4200`.
4. The application should load, and you can register/login as a user or admin.

## API Endpoints

### AuthController

- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Login a user

### AdminController

- `GET /api/admin/pending/questions` - Get pending questions
- `GET /api/admin/pending/answers` - Get pending answers
- `GET /api/admin/rejected/questions` - Get rejected questions
- `GET /api/admin/rejected/answers` - Get rejected answers
- `GET /api/admin/approved/questions` - Get approved questions
- `GET /api/admin/approved/answers` - Get approved answers
- `POST /api/admin/approve/question/{id}` - Approve a question
- `POST /api/admin/reject/question/{id}` - Reject a question
- `POST /api/admin/approve/answer/{id}` - Approve an answer
- `POST /api/admin/reject/answer/{id}` - Reject an answer
- `DELETE /api/admin/question/{id}` - Delete a question
- `DELETE /api/admin/answer/{id}` - Delete an answer
- `GET /api/admin/total/users` - Get total users count
- `GET /api/admin/total/questions` - Get total questions count
- `GET /api/admin/users` - Get all users
- `DELETE /api/admin/user/{id}` - Delete a user
- `GET /api/admin/questions-with-answers-and-users` - Get questions with answers and users
- `POST /api/admin/user` - Add a user
- `PUT /api/admin/user/{id}` - Update a user

### AnswersController

- `GET /api/answers/by-question/{questionId}` - Get answers for a question
- `POST /api/answers` - Create a new answer

### ImagesController

- `POST /api/images/upload` - Upload an image
- `GET /api/images/{id}/{index?}` - Get image by ID and index
- `GET /api/images/by-imageid/{imageId}` - Get image by image ID
- `GET /api/images/by-question-or-answer` - Get images by question or answer ID

### QuestionsController

- `GET /api/questions` - Get all questions
- `GET /api/questions/{id}` - Get a specific question
- `POST /api/questions` - Create a new question
- `GET /api/questions/search` - Search questions

## Additional Notes

- The backend uses JWT for authentication and session management.
- CORS is configured to allow requests from `http://localhost:4200`.
- SignalR is used for real-time notifications.
- Unit tests can be run from the `TestApp.Tests` directory using `dotnet test`.

## Troubleshooting

- If you encounter database connection issues, verify your SQL Server instance is running and the connection string is correct.
- Ensure ports 5001 (backend) and 4200 (frontend) are not in use by other applications.
- For HTTPS issues, you may need to trust the development certificate: `dotnet dev-certs https --trust`.

## Contributing

Please follow the existing code style and add tests for new features.
