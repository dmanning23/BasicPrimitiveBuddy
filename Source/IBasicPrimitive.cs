using Microsoft.Xna.Framework;

namespace BasicPrimitiveBuddy
{
	/// <summary>
	/// Render a simple 2D shape.
	/// </summary>
	public interface IBasicPrimitive
	{
		#region Public Methods

		/// <summary>
		/// draw a single point
		/// </summary>
		/// <param name="vPosition">where to draw the point</param>
		/// <param name="myColor">color of the circle to draw</param>
		void Point(Vector2 vPosition, Color myColor);

		/// <summary>
		/// draw a quick circle
		/// </summary>
		/// <param name="vPosition">where to draw the circle</param>
		/// <param name="fRadius">radius of the desired circle</param>
		/// <param name="myColor">color of the circle to draw</param>
		void Circle(Vector2 vPosition, float fRadius, Color myColor);

		/// <summary>
		/// draw a quick line
		/// </summary>
		/// <param name="start">start point</param>
		/// <param name="end">end point</param>
		/// <param name="myColor">color of the line to draw</param>
		void Line(Vector2 start, Vector2 end, Color myColor);

		/// <summary>
		/// draw a quick box
		/// </summary>
		/// <param name="vUpperLeft">start point</param>
		/// <param name="vLowerRight">end point</param>
		/// <param name="myColor">color of the line to draw</param>
		void AxisAlignedBox(Vector2 vUpperLeft, Vector2 vLowerRight, Color myColor);

		/// <summary>
		/// draw a quick box
		/// </summary>
		/// <param name="rect">the rectangle to draw</param>
		/// <param name="myColor">color of the line to draw</param>
		void Rectangle(Rectangle rect, Color myColor);

		/// <summary>
		/// Draw a stupid rectanlge.
		/// This is the easiest way to draw a rectangle
		/// </summary>
		/// <param name="vUpperLeft">start point</param>
		/// <param name="vLowerRight">end point</param>
		/// <param name="fScale">the scale to draw the rectangle</param>
		/// <param name="myColor">the color to use to draw the rectangle</param>
		void Rectangle(Vector2 vUpperLeft, Vector2 vLowerRight, float fRotation, float fScale, Color myColor);

		/// <summary>
		/// draw a pie shape
		/// </summary>
		/// <param name="Position">location to draw the pie</param>
		/// <param name="iRadius">the radius of the pie</param>
		/// <param name="fStartAngle">the angle to start the pie</param>
		/// <param name="fSweepAngle">the sweep angle of the pie</param>
		/// <param name="rColor">color dat pie</param>
		void Pie(
			Vector2 Position,
			int iRadius,
			float fStartAngle,
			float fSweepAngle,
			Microsoft.Xna.Framework.Color rColor);

		/// <summary>
		/// Get/Set the thickness of the shape's edge.
		/// </summary>
		float Thickness { get; set; }

		#endregion // Public Methods
	}
}