namespace StoreTests;

using StoreBLL.Services;

/// <summary>
/// Verifies <see cref="OrderStateTransitionValidator"/> against the state machine in OrderStatusChanges.jpg.
/// </summary>
public class OrderStateTransitionValidatorTests
{
    [Theory]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.Confirmed)]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.CanceledByUser)]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.CanceledByAdministrator)]
    [InlineData(OrderStateIds.Confirmed, OrderStateIds.MovedToDeliveryCompany)]
    [InlineData(OrderStateIds.Confirmed, OrderStateIds.CanceledByUser)]
    [InlineData(OrderStateIds.Confirmed, OrderStateIds.CanceledByAdministrator)]
    [InlineData(OrderStateIds.MovedToDeliveryCompany, OrderStateIds.InDelivery)]
    [InlineData(OrderStateIds.MovedToDeliveryCompany, OrderStateIds.CanceledByAdministrator)]
    [InlineData(OrderStateIds.InDelivery, OrderStateIds.DeliveredToClient)]
    [InlineData(OrderStateIds.InDelivery, OrderStateIds.CanceledByAdministrator)]
    [InlineData(OrderStateIds.DeliveredToClient, OrderStateIds.DeliveryConfirmedByClient)]
    [InlineData(OrderStateIds.DeliveredToClient, OrderStateIds.CanceledByUser)]
    public void IsTransitionAllowed_AllowsEveryEdgeInTheDiagram(int from, int to)
    {
        Assert.True(OrderStateTransitionValidator.IsTransitionAllowed(from, to));
    }

    [Theory]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.MovedToDeliveryCompany)]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.InDelivery)]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.DeliveredToClient)]
    [InlineData(OrderStateIds.NewOrder, OrderStateIds.DeliveryConfirmedByClient)]
    [InlineData(OrderStateIds.Confirmed, OrderStateIds.InDelivery)]
    [InlineData(OrderStateIds.Confirmed, OrderStateIds.DeliveredToClient)]
    [InlineData(OrderStateIds.Confirmed, OrderStateIds.NewOrder)]
    [InlineData(OrderStateIds.MovedToDeliveryCompany, OrderStateIds.DeliveredToClient)]
    [InlineData(OrderStateIds.MovedToDeliveryCompany, OrderStateIds.CanceledByUser)]
    [InlineData(OrderStateIds.InDelivery, OrderStateIds.MovedToDeliveryCompany)]
    [InlineData(OrderStateIds.InDelivery, OrderStateIds.CanceledByUser)]
    [InlineData(OrderStateIds.DeliveredToClient, OrderStateIds.CanceledByAdministrator)]
    [InlineData(OrderStateIds.DeliveredToClient, OrderStateIds.Confirmed)]
    public void IsTransitionAllowed_RejectsEdgesNotInTheDiagram(int from, int to)
    {
        Assert.False(OrderStateTransitionValidator.IsTransitionAllowed(from, to));
    }

    [Theory]
    [InlineData(OrderStateIds.CanceledByUser)]
    [InlineData(OrderStateIds.CanceledByAdministrator)]
    [InlineData(OrderStateIds.DeliveryConfirmedByClient)]
    public void IsTransitionAllowed_TerminalStatesAllowNoFurtherTransitions(int terminalState)
    {
        var allStates = new[]
        {
            OrderStateIds.NewOrder,
            OrderStateIds.CanceledByUser,
            OrderStateIds.CanceledByAdministrator,
            OrderStateIds.Confirmed,
            OrderStateIds.MovedToDeliveryCompany,
            OrderStateIds.InDelivery,
            OrderStateIds.DeliveredToClient,
            OrderStateIds.DeliveryConfirmedByClient,
        };

        Assert.All(allStates, state => Assert.False(OrderStateTransitionValidator.IsTransitionAllowed(terminalState, state)));
    }

    [Fact]
    public void GetAllowedNextStates_ForNewOrder_MatchesDiagram()
    {
        var next = OrderStateTransitionValidator.GetAllowedNextStates(OrderStateIds.NewOrder);

        Assert.Equal(3, next.Count);
        Assert.Contains(OrderStateIds.Confirmed, next);
        Assert.Contains(OrderStateIds.CanceledByUser, next);
        Assert.Contains(OrderStateIds.CanceledByAdministrator, next);
    }

    [Fact]
    public void GetAllowedNextStates_ForTerminalState_IsEmpty()
    {
        var next = OrderStateTransitionValidator.GetAllowedNextStates(OrderStateIds.DeliveryConfirmedByClient);

        Assert.Empty(next);
    }
}
