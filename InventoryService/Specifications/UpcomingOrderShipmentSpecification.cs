using System;
using InventoryService.Entity;

namespace InventoryService.Specifications
{
	public class UpcomingOrderShipmentSpecification : BaseSpecifcation<Order>
	{
		public UpcomingOrderShipmentSpecification() : base(x => x.ShipmentDate > DateTime.Now)
		{
			AddOrderBy(x => x.ShipmentDate);
		}
	}
}
