using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Dto.Request
{
	public class OrderRequest
	{
		public string Name { get; set; }
		public DateTime ShipmentDate { get; set; }
	}
}
