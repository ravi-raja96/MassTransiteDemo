using OrderService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Repositories.Specification
{
	public class UpcomingOrderShipmentSpecification : BaseSpecifcation<Order>
	{
		public UpcomingOrderShipmentSpecification() : base(x => x.ShipmentDate > DateTime.Now)
		{
			AddOrderBy(x => x.ShipmentDate);
		}
	}
}
