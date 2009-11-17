using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace CryoLib {
	public class ProblemImageCollection {
		private string baseURI;
		private string intro;
		private string success;
		private string failPowerLimit;
		private string failTooHot;
		private string failStrutBreaks;
		private PickerImageCollection pickerImageCollection;

		public string BaseURI {
			get { return baseURI; }
			set { baseURI = value; }
		}

		public string Intro {
			get { return intro; }
			set { intro = value; }
		}

		public string Success {
			get { return success; }
			set { success = value; }
		}

		public string FailPowerLimit {
			get { return failPowerLimit; }
			set { failPowerLimit = value; }
		}

		public string FailTooHot {
			get { return failTooHot; }
			set { failTooHot = value; }
		}

		public string FailStrutBreaks {
			get { return failStrutBreaks; }
			set { failStrutBreaks = value; }
		}

		public PickerImageCollection PickerImageCollection {
			get { return pickerImageCollection; }
			set { pickerImageCollection = value; }
		}

		public ProblemImageCollection(
								string baseURI,
								string intro,
								string success,
								string failPowerLimit,
								string failTooHot,
								string failStrutBreaks,
								PickerImageCollection pickerImageCollection)
		{
			this.baseURI = baseURI;
			this.intro = intro;
			this.success = success;
			this.failPowerLimit = failPowerLimit;
			this.failTooHot = failTooHot;
			this.failStrutBreaks = failStrutBreaks;
			this.pickerImageCollection = pickerImageCollection;
		}

		public ProblemImageCollection( XPathNavigator navigator ) {

			navigator.MoveToChild("baseURI", "");
			baseURI = navigator.Value;

			navigator.MoveToNext("intro", "");
			intro = navigator.Value;

			navigator.MoveToNext("success", "");
			success = navigator.Value;

			navigator.MoveToNext("failPowerLimitExceeded", "");
			failPowerLimit = navigator.Value;

			navigator.MoveToNext("failTargetTempNotMet", "");
			failTooHot = navigator.Value;

			navigator.MoveToNext("failStrutBreaks", "");
			failStrutBreaks = navigator.Value;

			navigator.MoveToNext("pickerImageArray", "");
			pickerImageCollection = new PickerImageCollection(navigator.Clone());

		}

		/// <summary>
		/// This parameterless constructor is required for XML serialization.
		/// </summary>
		public ProblemImageCollection() {}

	}

}
