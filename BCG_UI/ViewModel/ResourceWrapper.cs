using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{

	public class ResourceWrapper : ModelWrapper<Resources>
	{
		public ResourceWrapper(Resources model) : base(model)
		{

		}



		public string ResourceName
		{
			get { return GetValue<string>(); }
			set
			{
				SetValue(value);

			}
		}


		public short ResourceID
		{
			get { return GetValue<short>(); }
			set
			{
				SetValue(value);
			}
		}

		protected override IEnumerable<string> ValidateProperty(string propertyName)
		{
			switch (propertyName)
			{
				case nameof(ResourceName):
					if (string.Equals(ResourceName, "ww", StringComparison.InvariantCultureIgnoreCase))
					{
						yield return "Error";
					}
					break;
			}

		}
	}
}
