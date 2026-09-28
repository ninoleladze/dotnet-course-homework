namespace StoreBLL.Services;
using System.Collections.Generic;

/// <summary>
/// Validates order status changes against the allowed state machine (see OrderStatusChanges.jpg):
/// New Order -&gt; Confirmed / Canceled by user / Canceled by administrator;
/// Confirmed -&gt; Moved to delivery company / Canceled by user / Canceled by administrator;
/// Moved to delivery company -&gt; In delivery / Canceled by administrator;
/// In delivery -&gt; Delivered to client / Canceled by administrator;
/// Delivered to client -&gt; Delivery confirmed by client / Canceled by user.
/// Canceled by user, Canceled by administrator and Delivery confirmed by client are terminal states.
/// </summary>
public static class OrderStateTransitionValidator
{
    private static readonly IReadOnlyDictionary<int, IReadOnlySet<int>> AllowedTransitions =
        new Dictionary<int, IReadOnlySet<int>>
        {
            [OrderStateIds.NewOrder] = new HashSet<int>
            {
                OrderStateIds.Confirmed,
                OrderStateIds.CanceledByUser,
                OrderStateIds.CanceledByAdministrator,
            },
            [OrderStateIds.Confirmed] = new HashSet<int>
            {
                OrderStateIds.MovedToDeliveryCompany,
                OrderStateIds.CanceledByUser,
                OrderStateIds.CanceledByAdministrator,
            },
            [OrderStateIds.MovedToDeliveryCompany] = new HashSet<int>
            {
                OrderStateIds.InDelivery,
                OrderStateIds.CanceledByAdministrator,
            },
            [OrderStateIds.InDelivery] = new HashSet<int>
            {
                OrderStateIds.DeliveredToClient,
                OrderStateIds.CanceledByAdministrator,
            },
            [OrderStateIds.DeliveredToClient] = new HashSet<int>
            {
                OrderStateIds.DeliveryConfirmedByClient,
                OrderStateIds.CanceledByUser,
            },
        };

    /// <summary>
    /// Determines whether an order may move from <paramref name="currentStateId"/> to <paramref name="newStateId"/>.
    /// </summary>
    /// <param name="currentStateId">The order's current state identifier.</param>
    /// <param name="newStateId">The requested new state identifier.</param>
    /// <returns><see langword="true"/> if the transition is allowed by the state machine; otherwise <see langword="false"/>.</returns>
    public static bool IsTransitionAllowed(int currentStateId, int newStateId)
    {
        return AllowedTransitions.TryGetValue(currentStateId, out var next) && next.Contains(newStateId);
    }

    /// <summary>
    /// Gets the set of state identifiers an order may move to from <paramref name="currentStateId"/>.
    /// </summary>
    /// <param name="currentStateId">The order's current state identifier.</param>
    /// <returns>The allowed next state identifiers; empty for terminal states.</returns>
    public static IReadOnlySet<int> GetAllowedNextStates(int currentStateId)
    {
        return AllowedTransitions.TryGetValue(currentStateId, out var next) ? next : new HashSet<int>();
    }
}
