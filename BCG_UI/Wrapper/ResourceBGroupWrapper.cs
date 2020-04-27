using Model;

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


		public string ValidDisbalance
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

	}
}
