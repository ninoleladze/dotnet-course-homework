namespace StoreBLL.Services;

/// <summary>
/// Fixed order-state identifiers, matching the order-state seed data
/// (see <see cref="StoreDAL.Data.InitDataFactory.TestDataFactory.GetOrderStateData"/> and
/// <see cref="StoreDAL.Data.InitDataFactory.ReleaseDataFactory.GetOrderStateData"/>).
/// </summary>
public static class OrderStateIds
{
    /// <summary>A freshly placed order.</summary>
    public const int NewOrder = 1;

    /// <summary>The order was cancelled by the customer.</summary>
    public const int CanceledByUser = 2;

    /// <summary>The order was cancelled by an administrator.</summary>
    public const int CanceledByAdministrator = 3;

    /// <summary>The order was confirmed by an administrator.</summary>
    public const int Confirmed = 4;

    /// <summary>The order was handed off to the delivery company.</summary>
    public const int MovedToDeliveryCompany = 5;

    /// <summary>The order is in transit.</summary>
    public const int InDelivery = 6;

    /// <summary>The delivery company marked the order as delivered.</summary>
    public const int DeliveredToClient = 7;

    /// <summary>The customer confirmed they received the order.</summary>
    public const int DeliveryConfirmedByClient = 8;
}
