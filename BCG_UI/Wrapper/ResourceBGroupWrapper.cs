using Model;
using System.Collections.Generic;

namespace BCG_UI.ViewModel.Wrapper
{
	public class ResourceBGroupWrapper : ModelWrapper<BGroups>
	{
		public ResourceBGroupWrapper(BGroups model) : base(model)
		{

		}

		public string BGroupName
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string BGroupIDParent
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}


		public float ValidDisbalance
		{
			get { return GetValue<float>(); }
			set { SetValue(value); }
		}

		
		public ICollection<BGroups> BGroups1
		{
			get { return GetValue<ICollection<BGroups>>(); }
			set { SetValue(value); }
		}

	}
}
