using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DoConnectBackend.Controllers;
using DoConnectBackend.Data;
using DoConnectBackend.Models;
using DoConnectBackend.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

namespace TestApp.Tests;

public class UnitTest1
{
    private readonly ApplicationDbContext _db;
    private readonly Mock<IHubContext<NotificationHub>> _mockHub;
    private readonly QuestionsController _controller;

    public UnitTest1()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "DoConnectDb")
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
}
