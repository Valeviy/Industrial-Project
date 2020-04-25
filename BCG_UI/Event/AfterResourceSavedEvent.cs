using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Event
{
	public class AfterResourceSavedEvent : PubSubEvent<AfterResourceSavedEventArgs>
{

	}


	public class AfterResourceSavedEventArgs
	{
		public int Id { get; set; }
		public string DisplayMember { get; set; }
	}
}
