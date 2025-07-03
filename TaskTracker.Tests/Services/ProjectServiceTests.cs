using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Services;
using Xunit;

namespace TaskTracker.Tests.Services
{
    public class ProjectServiceTests
    {
        private readonly Mock<IProjectRepository> _projectRepoMock;
        private readonly ProjectService _service;

        public ProjectServiceTests()
        {
            _projectRepoMock = new Mock<IProjectRepository>();
            _service = new ProjectService(_projectRepoMock.Object);
        }

        [Fact]
        public async Task CreateAsync_CallsAddAsyncOnce()
        {
            // Arrange
            var userId = Guid.NewGuid();

            var dto = new ProjectDto
            {
                Title = "Новый проект"
            };

            _projectRepoMock
                .Setup(repo => repo.AddAsync(It.IsAny<Project>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            await _service.CreateAsync(dto, userId);

            // Assert
            _projectRepoMock.Verify(
                repo => repo.AddAsync(It.Is<Project>(p => p.Title == dto.Title && p.UserId == userId)),
                Times.Once);
        }

    }
}
