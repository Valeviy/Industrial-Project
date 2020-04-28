using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Event
{
	public class AfterDetailDeletedEvent : PubSubEvent<AfterDetailDeletedEventArgs>
	{

	}

	public class AfterDetailDeletedEventArgs
	{
		public int Id { get; set; }
		public string ViewModelName { get; set; }
	}
}
