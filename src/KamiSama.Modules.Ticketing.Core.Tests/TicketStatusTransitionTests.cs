using KamiSama.Chassis.HttpExceptions;
using KamiSama.Modules.Ticketing.DataTypes;
using KamiSama.Modules.Ticketing.Entities;
using KamiSama.Modules.Ticketing.Features.Tickets;
using KamiSama.Modules.Ticketing.Repositories.Abstractions;
using NSubstitute;

namespace KamiSama.Modules.Ticketing.Core.Tests;

[TestClass]
public class TicketStatusTransitionTests
{
	[DataTestMethod]
	[DataRow(TicketStatus.Open, TicketStatus.Open, true)]
	[DataRow(TicketStatus.Open, TicketStatus.Resolved, true)]
	[DataRow(TicketStatus.Open, TicketStatus.Reopened, false)]
	[DataRow(TicketStatus.Open, TicketStatus.Closed, false)]
	[DataRow(TicketStatus.Reopened, TicketStatus.Reopened, true)]
	[DataRow(TicketStatus.Reopened, TicketStatus.Resolved, true)]
	[DataRow(TicketStatus.Reopened, TicketStatus.Open, false)]
	[DataRow(TicketStatus.Reopened, TicketStatus.Closed, false)]
	[DataRow(TicketStatus.Resolved, TicketStatus.Resolved, true)]
	[DataRow(TicketStatus.Resolved, TicketStatus.Reopened, true)]
	[DataRow(TicketStatus.Resolved, TicketStatus.Closed, true)]
	[DataRow(TicketStatus.Resolved, TicketStatus.Open, false)]
	[DataRow(TicketStatus.Closed, TicketStatus.Closed, true)]
	[DataRow(TicketStatus.Closed, TicketStatus.Open, false)]
	[DataRow(TicketStatus.Closed, TicketStatus.Reopened, false)]
	[DataRow(TicketStatus.Closed, TicketStatus.Resolved, false)]
	[DataRow((TicketStatus)99, TicketStatus.Open, false)]
	[DataRow(TicketStatus.Open, (TicketStatus)99, false)]
	public void CanTransitionTo_returns_expected_result(TicketStatus current, TicketStatus target, bool expected)
	{
		Ticket ticket = CreateTicket(current);

		Assert.AreEqual(expected, ticket.CanTransitionTo(target));
	}

	[TestMethod]
	public async Task UpdateAsync_applies_valid_transition_and_saves()
	{
		ITicketRepository repository = Substitute.For<ITicketRepository>();
		Ticket ticket = CreateTicket(TicketStatus.Open);
		repository.FindByIdAsync(ticket.Id, Arg.Any<CancellationToken>()).Returns(ticket);
		var feature = new UpdateTicketState(repository);

		await feature.UpdateAsync(
			ticket.Id,
			new UpdateTicketStateRequest("Changed", TicketStatus.Resolved, TicketPriority.High),
			CancellationToken.None);

		Assert.AreEqual(TicketStatus.Resolved, ticket.Status);
		Assert.AreEqual(TicketPriority.High, ticket.Priority);
		Assert.AreEqual("Changed", ticket.Title);
		await repository.Received(1).UpdateAsync(ticket, Arg.Any<CancellationToken>());
	}

	[TestMethod]
	public async Task UpdateAsync_rejects_invalid_transition_without_saving()
	{
		ITicketRepository repository = Substitute.For<ITicketRepository>();
		Ticket ticket = CreateTicket(TicketStatus.Open);
		repository.FindByIdAsync(ticket.Id, Arg.Any<CancellationToken>()).Returns(ticket);
		var feature = new UpdateTicketState(repository);

		await Assert.ThrowsExceptionAsync<ConflictException>(() => feature.UpdateAsync(
			ticket.Id,
			new UpdateTicketStateRequest("Changed", TicketStatus.Closed, TicketPriority.High),
			CancellationToken.None));

		Assert.AreEqual(TicketStatus.Open, ticket.Status);
		Assert.AreEqual("Ticket", ticket.Title);
		await repository.DidNotReceive().UpdateAsync(Arg.Any<Ticket>(), Arg.Any<CancellationToken>());
	}

	private static Ticket CreateTicket(TicketStatus status) => new()
	{
		Id = Guid.NewGuid(),
		Title = "Ticket",
		AuthorUserId = Guid.NewGuid(),
		Status = status,
		Priority = TicketPriority.Medium,
		CreatedAt = DateTime.UtcNow,
		UpdatedAt = DateTime.UtcNow,
		Category = new TicketCategory
		{
			Id = Guid.NewGuid(),
			Name = "Support",
			CreatedAt = DateTime.UtcNow,
			UpdatedAt = DateTime.UtcNow
		}
	};
}
