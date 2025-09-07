using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DoConnectBackend.Controllers;
using DoConnectBackend.Data;
using DoConnectBackend.Models;
using DoConnectBackend.Services;
using DoConnectBackend.Dtos;
using DoConnectBackend.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Controllers;
using BCrypt.Net;

namespace TestApp.Tests;

public class UnitTest1
{
    private readonly ApplicationDbContext _db;
    private readonly Mock<IHubContext<NotificationHub>> _mockHub;
    private readonly QuestionsController _controller;

    public UnitTest1()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _db = new ApplicationDbContext(options);
        _mockHub = new Mock<IHubContext<NotificationHub>>();
        _controller = new QuestionsController(_db, _mockHub.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsQuestions()
    {
        // Arrange
        var user = new User { UserId = 1, Username = "testuser", PasswordHash = "hash" };
        var question = new Question { QuestionId = "q1", Title = "Test", Text = "Test question", Status = "Approved", UserId = 1, User = user };
        _db.Users.Add(user);
        _db.Questions.Add(question);
        await _db.SaveChangesAsync();

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task Get_ValidId_ReturnsQuestion()
    {
        // Arrange
        var user = new User { UserId = 2, Username = "testuser2", PasswordHash = "hash" };
        var question = new Question { QuestionId = "q2", Title = "Test", Text = "Test question", Status = "Approved", UserId = 2, User = user };
        _db.Users.Add(user);
        _db.Questions.Add(question);
        await _db.SaveChangesAsync();

        // Act
        var result = await _controller.Get("q2");

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task AdminController_AddUser_ReturnsOk()
    {
        // Arrange
        var adminController = new AdminController(_db);
        var request = new AdminController.AddUserRequest("newuser", "password", "User");

        // Act
        var result = await adminController.AddUser(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == "newuser");
        Assert.NotNull(user);
        Assert.True(BCrypt.Net.BCrypt.Verify("password", user.PasswordHash));
    }

    [Fact]
    public async Task AdminController_UpdateUser_ReturnsOk()
    {
        // Arrange
        var user = new User { UserId = 1, Username = "updateuser", PasswordHash = BCrypt.Net.BCrypt.HashPassword("oldpass"), Role = "User" };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        var adminController = new AdminController(_db);
        var request = new AdminController.UpdateUserRequest(null, "newpass", "Admin");

        // Act
        var result = await adminController.UpdateUser(user.UserId.ToString(), request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var updatedUser = await _db.Users.FirstOrDefaultAsync(u => u.Username == "updateuser");
        Assert.NotNull(updatedUser);
        Assert.True(BCrypt.Net.BCrypt.Verify("newpass", updatedUser.PasswordHash));
        Assert.Equal("Admin", updatedUser.Role);
    }

    [Fact]
    public async Task AuthController_Register_ReturnsOk()
    {
        // Arrange
        var mockTokenService = new Mock<ITokenService>();
        mockTokenService.Setup(t => t.Create(It.IsAny<User>())).Returns("token");
        var authController = new AuthController(_db, mockTokenService.Object);
        var request = new RegisterRequest("reguser", "regpass", "User");

        // Act
        var result = await authController.Register(request);

        // Assert
        Assert.IsType<ActionResult<AuthResponse>>(result);
        Assert.NotNull(result.Value);
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == "reguser");
        Assert.NotNull(user);
    }

    [Fact]
    public async Task AuthController_Login_ReturnsOk()
    {
        // Arrange
        var user = new User { Username = "loginuser", PasswordHash = BCrypt.Net.BCrypt.HashPassword("loginpass"), Role = "User" };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        var mockTokenService = new Mock<ITokenService>();
        mockTokenService.Setup(t => t.Create(It.IsAny<User>())).Returns("token");
        var authController = new AuthController(_db, mockTokenService.Object);
        var request = new LoginRequest("loginuser", "loginpass");

        // Act
        var result = await authController.Login(request);

        // Assert
        Assert.IsType<ActionResult<AuthResponse>>(result);
        Assert.NotNull(result.Value);
    }
}
