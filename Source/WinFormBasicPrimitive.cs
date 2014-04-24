using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Drawing;

namespace BasicPrimitiveBuddy
{
	/// <summary>
	/// Render a simple 2D shape.
	/// </summary>
	public class WinFormBasicPrimitive : IBasicPrimitive
	{
		#region Members

		/// <summary>
		/// the form that this dude will render to
		/// </summary>
		public BufferedGraphics DoubleBuffer { get; set; }

		#endregion //Members

		#region Initialization

		/// <summary>
		/// Creates a new primitive object.
		/// </summary>
		/// <param name="_graphicsDevice">The graphics device object to use.</param>
		public WinFormBasicPrimitive()
		{
		}

		#endregion // Initialization

		#region Public Methods

		/// <summary>
		/// draw a single point
		/// </summary>
		/// <param name="vPosition">where to draw the point</param>
		/// <param name="myColor">color of the circle to draw</param>
		public void Point(Vector2 Position, Microsoft.Xna.Framework.Color rColor)
		{
			//Get teh grpahics object
			Debug.Assert(null != DoubleBuffer);

			//get a brush of the correct color
			System.Drawing.Color myColor = System.Drawing.Color.FromArgb(rColor.A, rColor.R, rColor.G, rColor.B);
			Brush myBrush = new SolidBrush(myColor);

			//draw an ellipse
			DoubleBuffer.Graphics.FillEllipse(myBrush, Position.X - 2, Position.Y - 2, 5.0f, 5.0f);
		}

		/// <summary>
		/// draw a quick circle
		/// </summary>
		/// <param name="vPosition">where to draw the circle</param>
		/// <param name="fRadius">radius of the desired circle</param>
		/// <param name="myColor">color of the circle to draw</param>
		public void Circle(Vector2 Position, float iRadius, Microsoft.Xna.Framework.Color rColor)
		{
			//Get the graphics object
			Debug.Assert(null != DoubleBuffer);

			//set the transform
			DoubleBuffer.Graphics.Transform = new System.Drawing.Drawing2D.Matrix();
			Debug.Assert(DoubleBuffer.Graphics.Transform.IsIdentity);

			//get a pen of the correct color
			System.Drawing.Color myColor = System.Drawing.Color.FromArgb(rColor.A, rColor.R, rColor.G, rColor.B);
			Pen myPen = new Pen(myColor);

			DoubleBuffer.Graphics.DrawEllipse(myPen, (Position.X - iRadius), (Position.Y - iRadius), (iRadius * 2), (iRadius * 2));
		}

		/// <summary>
		/// draw a quick line
		/// </summary>
		/// <param name="start">start point</param>
		/// <param name="end">end point</param>
		/// <param name="myColor">color of the line to draw</param>
		public void Line(Vector2 start, Vector2 end, Microsoft.Xna.Framework.Color myColor)
		{
			//Get the graphics object
			Debug.Assert(null != DoubleBuffer);

			//set the transform
			DoubleBuffer.Graphics.Transform = new System.Drawing.Drawing2D.Matrix();
			Debug.Assert(DoubleBuffer.Graphics.Transform.IsIdentity);

			//get a pen of the correct color
			System.Drawing.Color gdiColor = System.Drawing.Color.FromArgb(myColor.A, myColor.R, myColor.G, myColor.B);
			Pen myPen = new Pen(gdiColor);

			//draw the 4 lines for the rectangle
			DoubleBuffer.Graphics.DrawLine(myPen, start.X, start.Y, end.X, end.Y);
		}

		/// <summary>
		/// draw a quick box
		/// </summary>
		/// <param name="vUpperLeft">start point</param>
		/// <param name="vLowerRight">end point</param>
		/// <param name="myColor">color of the line to draw</param>
		public void AxisAlignedBox(Vector2 vUpperLeft, Vector2 vLowerRight, Microsoft.Xna.Framework.Color myColor)
		{
			Rectangle(vUpperLeft, vLowerRight, 0.0f, 1.0f, myColor);
		}

		/// <summary>
		/// draw a quick box
		/// </summary>
		/// <param name="rect">the rectangle to draw</param>
		/// <param name="myColor">color of the line to draw</param>
		public void Rectangle(Microsoft.Xna.Framework.Rectangle rect, Microsoft.Xna.Framework.Color myColor)
		{
			AxisAlignedBox(new Vector2(rect.Left, rect.Top),
			               new Vector2(rect.Left + rect.Width, rect.Top + rect.Height),
			               myColor);
		}

		/// <summary>
		/// Draw a stupid rectanlge.
		/// This is the easiest way to draw a rectangle
		/// </summary>
		/// <param name="vUpperLeft">start point</param>
		/// <param name="vLowerRight">end point</param>
		/// <param name="fScale">the scale to draw the rectangle</param>
		/// <param name="myColor">the color to use to draw the rectangle</param>
		public void Rectangle(Vector2 vUpperLeft, Vector2 vLowerRight, float fRotation, float fScale, Microsoft.Xna.Framework.Color myColor)
		{
			//Get the graphics object
			Debug.Assert(null != DoubleBuffer);

			//set the transform
			DoubleBuffer.Graphics.Transform = new System.Drawing.Drawing2D.Matrix();
			Debug.Assert(DoubleBuffer.Graphics.Transform.IsIdentity);

			//setup the scale matrix
			System.Drawing.Drawing2D.Matrix ScaleMatrix = new System.Drawing.Drawing2D.Matrix();
			ScaleMatrix.Scale(fScale, fScale);

			//setup the rotation matrix
			System.Drawing.Drawing2D.Matrix RotationMatrix = new System.Drawing.Drawing2D.Matrix();
			RotationMatrix.Rotate(MathHelper.ToDegrees(fRotation));

			//setup the translation matrix
			System.Drawing.Drawing2D.Matrix TranslationMatrix = new System.Drawing.Drawing2D.Matrix();
			TranslationMatrix.Translate(vUpperLeft.X, vUpperLeft.Y);

			//setup the "move back from origin" matrix
			System.Drawing.Drawing2D.Matrix OriginMatrix = new System.Drawing.Drawing2D.Matrix();
			OriginMatrix.Translate(-vUpperLeft.X, -vUpperLeft.Y);

			TranslationMatrix.Multiply(RotationMatrix);
			TranslationMatrix.Multiply(ScaleMatrix);
			TranslationMatrix.Multiply(OriginMatrix);

			DoubleBuffer.Graphics.Transform = TranslationMatrix;

			//get a pen of the correct color
			System.Drawing.Color gdiColor = System.Drawing.Color.FromArgb(myColor.A, myColor.R, myColor.G, myColor.B);
			Pen myPen = new Pen(gdiColor);

			//draw the 4 lines for the rectangle
			DoubleBuffer.Graphics.DrawLine(myPen, vUpperLeft.X, vUpperLeft.Y, vLowerRight.X, vUpperLeft.Y);
			DoubleBuffer.Graphics.DrawLine(myPen, vLowerRight.X, vUpperLeft.Y, vLowerRight.X, vLowerRight.Y);
			DoubleBuffer.Graphics.DrawLine(myPen, vLowerRight.X, vLowerRight.Y, vUpperLeft.X, vLowerRight.Y);
			DoubleBuffer.Graphics.DrawLine(myPen, vUpperLeft.X, vLowerRight.Y, vUpperLeft.X, vUpperLeft.Y);
		}

		/// <summary>
		/// draw a pie shape
		/// </summary>
		/// <param name="Position">location to draw the pie</param>
		/// <param name="iRadius">the radius of the pie</param>
		/// <param name="fStartAngle">the angle to start the pie</param>
		/// <param name="fSweepAngle">the sweep angle of the pie</param>
		/// <param name="rColor">color dat pie</param>
		public void Pie(
			Vector2 Position,
			int iRadius,
			float fStartAngle,
			float fSweepAngle,
			Microsoft.Xna.Framework.Color rColor)
		{
			//Get the graphics object
			Debug.Assert(null != DoubleBuffer);

			//set the transform
			DoubleBuffer.Graphics.Transform = new System.Drawing.Drawing2D.Matrix();
			Debug.Assert(DoubleBuffer.Graphics.Transform.IsIdentity);

			//get a pen of the correct color
			System.Drawing.Color myColor = System.Drawing.Color.FromArgb(rColor.A, rColor.R, rColor.G, rColor.B);
			Pen myPen = new Pen(myColor);

			DoubleBuffer.Graphics.DrawPie(myPen, (Position.X - iRadius), (Position.Y - iRadius), (iRadius * 2), (iRadius * 2),
				MathHelper.ToDegrees(fStartAngle),
				MathHelper.ToDegrees(fSweepAngle));
		}

		#endregion // Public Methods
	}
}