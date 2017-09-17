using System.Net.Sockets;
using Moq;
using PartyInvites.Abstract;
using PartyInvites.Controllers;
using PartyInvites.Models;
using Xunit;

namespace PartyInvites.Tests
{
	public class HomeControllerTests
	{

		[Fact]
		public void TestDoubleEmail()
		{
			//Arrange
			var mockRepo = new Mock<IRepository>();
			mockRepo.Setup(r => r.GetGuestResponse(It.IsAny<string>())).Returns(new GuestResponse
			{
				Credential = new Credential
				{
					Email = "unit@test.nl"
				},
				Name = "Unit Test",
				Phone = "0123456789",
				Address = "Unit Test 2",
				WillAttend = true
			});

			var controller = new HomeController(mockRepo.Object);

			//Act
			var model = controller.EmailForm(new Credential
			{
				Email = "unit@test.nl"
			}).ViewData.Model as GuestResponse;

			//Assert
			Assert.NotNull(model.Name);
			Assert.NotNull(model.Phone);
			Assert.NotNull(model.Credential.Email);
			Assert.NotNull(model.Address);
			Assert.NotNull(model.WillAttend);
		}
	}
}

