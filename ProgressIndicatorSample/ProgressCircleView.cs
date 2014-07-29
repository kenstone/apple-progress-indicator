using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreAnimation;

namespace ProgressIndicatorSample
{
	public class ProgressCircleView : UIView
	{
		protected CAShapeLayer _progressCircle;

		public override RectangleF Bounds {
			get {
				return base.Bounds;
			}
			set {
				base.Bounds = value;
				RedrawCircle ();
			}
		}

		public ProgressCircleView ()
		{
			RedrawCircle ();
		}

		/// <summary>
		/// Redraws the progress circle. If the circle is already on the screen, it removes that one and creates a new one using the 
		/// current properties of the view
		/// </summary>
		void RedrawCircle ()
		{
			if (_progressCircle != null && _progressCircle.SuperLayer != null) {
				_progressCircle.RemoveFromSuperLayer ();
			}

			var centerPoint = new PointF (this.Bounds.Width / 2, this.Bounds.Height / 2);
			UIBezierPath circlePath = UIBezierPath.FromArc (centerPoint, this.Bounds.Width * .7f, (float)(-.5 * Math.PI), (float)(1.5 * Math.PI), true);

			_progressCircle = new CAShapeLayer ();
			_progressCircle.Path = circlePath.CGPath;
			_progressCircle.StrokeColor = UIColor.Green.CGColor;
			_progressCircle.FillColor = UIColor.Clear.CGColor;
			_progressCircle.LineWidth = 1.5f;
			_progressCircle.StrokeStart = 0f;
			_progressCircle.StrokeEnd = 0f;

			this.Layer.AddSublayer (_progressCircle);
		}

		/// <summary>
		/// Updates the progress circle.
		/// </summary>
		/// <param name="progressPercent">The percentage of the progress. Should be a value between 0.0 and 1.0</param>
		public void UpdateProgress(float progressPercent) {
			_progressCircle.StrokeEnd = progressPercent;

		}
	}
}

