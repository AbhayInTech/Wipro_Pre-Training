# TODO List for Admin Rejected/Approved Questions and Answers Feature

- [x] Backend: DoConnectBackend/Controllers/AdminController.cs

  - [x] Add GET endpoint for rejected questions
  - [x] Add GET endpoint for rejected answers
  - [x] Add GET endpoint for approved questions
  - [x] Add GET endpoint for approved answers

- [x] Frontend: DoConnect/DoConnectFrontend/src/app/services/admin-service.ts

  - [x] Add methods to fetch rejected questions, rejected answers, approved questions, approved answers

- [x] Frontend: DoConnect/DoConnectFrontend/src/app/pages/admin/admin.ts

  - [x] Add properties for rejected and approved questions and answers
  - [x] Fetch rejected and approved questions and answers in refresh()

- [x] Frontend: DoConnect/DoConnectFrontend/src/app/pages/admin/admin.html

  - [x] Add UI sections for rejected questions, rejected answers, approved questions, approved answers similar to pending sections

- [x] Testing
  - [x] Fixed type mismatch in DeleteUser method (UserId is int, not string)
  - [x] Verified user list displays correctly with $values property
  - [x] Verified delete user functionality with confirmation dialog
