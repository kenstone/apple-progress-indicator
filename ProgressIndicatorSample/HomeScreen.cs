
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace ProgressIndicatorSample
{
	public partial class HomeScreen : UIViewController
	{
		public HomeScreen () : base ("HomeScreen", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var circleProgress = new ProgressCircleView ();
			circleProgress.Bounds = new RectangleF (0, 0, 100, 100);
			circleProgress.Frame = new RectangleF (100, 100, 100, 100);

			View.AddSubview (circleProgress);

			circleProgress.UpdateProgress (0.52f);
		}
	}
}

