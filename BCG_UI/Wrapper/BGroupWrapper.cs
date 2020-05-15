using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BCG_UI.ViewModel.Wrapper
{
	//implemented F1.7 requirement

	public class BGroupWrapper : ModelWrapper<BGroups>
	{
		public BGroupWrapper(BGroups model) : base(model)
		{

		}
		public int BGroupID
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}
		public string BGroupName
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public int? BGroupIDParent
		{
			get { return GetValue<int?>(); }
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
