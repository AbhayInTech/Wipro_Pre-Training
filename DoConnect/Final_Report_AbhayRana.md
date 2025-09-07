# Final Report - DoConnect Capstone Project

---

## Title Page

**Project Title:** DoConnect  
**Your Name:** Abhay Rana  
**Date:** 08-09-2025  
**Batch Name & Instructor Details:** .Net Full Stack Angular --- Parth Sukhla Sir

---

## Table of Contents

1. Problem Definition and Objectives
2. Frontend & Backend Architecture
3. System Design Overview
4. Component Breakdown & API Design
5. Database Design & Storage Optimization
6. Demonstration
7. References

---

## 1. Problem Definition and Objectives

### Problem Statement

DoConnect is designed to provide a platform for users to post questions and receive answers in a collaborative environment. The system aims to facilitate knowledge sharing with real-time updates and secure user authentication.

### Project Goals and Objectives

- Develop a full-stack web application with a responsive frontend and robust backend.
- Implement user authentication and role-based access control.
- Enable real-time notifications for approval of new questions and answers using SignalR.
- Design a scalable database schema to efficiently store questions, answers, users, and images.
- Provide a clean and intuitive user interface using Angular and Bootstrap.

---

## 2. Frontend & Backend Architecture

### Technology Stack

**Backend:**

- .NET 9.0 Web API
- Entity Framework Core with SQL Server
- JWT Bearer Authentication
- SignalR for real-time communication
- BCrypt for password hashing
- Swagger for API documentation

**Frontend:**

- Angular 20.1.0
- Bootstrap 5.3.8 and Bootstrap Icons
- Axios for HTTP requests
- JWT Decode for token management
- RxJS for reactive programming

---

## 3. System Design Overview

The system follows a client-server architecture with a RESTful API backend and a single-page application frontend. The backend exposes endpoints for managing questions, answers, and user authentication. SignalR hubs provide real-time notifications to connected clients.

---

## 4. Component Breakdown & API Design

### Frontend Components

- Authentication Service: Manages user login, registration, token storage, and role management.
- Question and Answer Components: Display lists, details, and forms for questions and answers.
- Real-time Notification Components: Listen to SignalR hubs for updates.

## API Endpoints

### AuthController

- POST /api/auth/register - Register a new user
- POST /api/auth/login - Login a user

### AdminController

- GET /api/admin/pending/questions - Get pending questions
- GET /api/admin/pending/answers - Get pending answers
- GET /api/admin/rejected/questions - Get rejected questions
- GET /api/admin/rejected/answers - Get rejected answers
- GET /api/admin/approved/questions - Get approved questions
- GET /api/admin/approved/answers - Get approved answers
- POST /api/admin/approve/question/{id} - Approve a question
- POST /api/admin/reject/question/{id} - Reject a question
- POST /api/admin/approve/answer/{id} - Approve an answer
- POST /api/admin/reject/answer/{id} - Reject an answer
- DELETE /api/admin/question/{id} - Delete a question
- DELETE /api/admin/answer/{id} - Delete an answer
- GET /api/admin/total/users - Get total users count
- GET /api/admin/total/questions - Get total questions count
- GET /api/admin/users - Get all users
- DELETE /api/admin/user/{id} - Delete a user
- GET /api/admin/questions-with-answers-and-users - Get questions with answers and users
- POST /api/admin/user - Add a user
- PUT /api/admin/user/{id} - Update a user

### AnswersController

- GET /api/answers/by-question/{questionId} - Get answers for a question
- POST /api/answers - Create a new answer

### ImagesController

- POST /api/images/upload - Upload an image
- GET /api/images/{id}/{index?} - Get image by ID and index
- GET /api/images/by-imageid/{imageId} - Get image by image ID
- GET /api/images/by-question-or-answer - Get images by question or answer ID

### QuestionsController

- GET /api/questions - Get all questions
- GET /api/questions/{id} - Get a specific question
- POST /api/questions - Create a new question
- GET /api/questions/search - Search questions

## 5. Database Design & Storage Optimization

### Entity-Relationship Diagram (ERD)

The database consists of the following main entities:

- **User:** Stores user credentials, roles, and related questions and answers.
- **Question:** Contains question details, status, related user, answers, and associated images.
- **Answer:** Contains answer details, status, related question, user, and images.
- **Image:** Stores image metadata linked to questions or answers.

### Optimization Techniques

- Use of indexes on key columns for faster queries.
- Storing image references as comma-separated IDs to reduce join complexity.
- Lazy loading and eager loading strategies with Entity Framework Core.

---

### Frontend Code :

- DoConnectFrontend
- contains full Angular source code

### backend Code :

- DoConnectBackend
- Contains full ASP.NET Core Web API source code

### Database & Configuration Files:

- Database_Schema_DoConnect.sql
- API configuration: appsettings.json
- Environment files: .env

### Deployment:

- https://github.com/AbhayInTech/Wipro_Pre-Training/tree/main/DoConnect
