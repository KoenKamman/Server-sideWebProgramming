using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using PartyInvites.Abstract;
using PartyInvites.Components;
using PartyInvites.Models;
using PartyInvites.Models.ViewModels;
using Xunit;

namespace PartyInvites.Tests
{
	public class CounterViewComponentTests
	{
		[Fact]
		public void TestAmounts()
		{
			//Arrange
			var mockRepo = new Mock<IRepository>();

			mockRepo.Setup(r => r.GetAllResponses()).Returns(new List<GuestResponse>
			{
				new GuestResponse
				{
					WillAttend = true
				},
				new GuestResponse
				{
					WillAttend = true
				},
				new GuestResponse
				{
					WillAttend = false
				}
			});

			var component = new CounterViewComponent(mockRepo.Object);

			//Act
			var result = component.Invoke() as ViewViewComponentResult;

			//Assert
			Assert.Equal(3, ((CounterViewModel)result.ViewData.Model).ResponseAmount);
			Assert.Equal(2, ((CounterViewModel)result.ViewData.Model).AttendingAmount);

		}
	}
}
