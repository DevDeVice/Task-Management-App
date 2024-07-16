using Xunit;
using Moq;
using TaskManagementApp.Controllers;
using TaskManagementApp.Models;
using TaskManagementApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TasksControllerTests
{
    [Fact]
    public async Task GetTasks_ReturnsOkResult_WithAListOfTaskItems()
    {
        // Arrange
        var mockService = new Mock<ITaskService>();
        mockService.Setup(service => service.GetTasks())
                   .ReturnsAsync(new List<TaskItem> { new TaskItem { Id = 1, Title = "Test Task", Description = "Test Description", IsComplete = false } });

        var controller = new TasksController(mockService.Object);

        // Act
        var result = await controller.GetTasks();

        // Assert
        var okResult = result.Result as OkObjectResult;
        Assert.NotNull(okResult);
        var returnValue = Assert.IsType<List<TaskItem>>(okResult.Value);
        Assert.Single(returnValue);
    }
}
