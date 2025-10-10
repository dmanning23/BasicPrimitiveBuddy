using Microsoft.Xna.Framework;

namespace PrimitiveBuddy
{
	/// <summary>
	/// Render a simple 2D shape.
	/// </summary>
	public interface IPrimitive
	{
		/// <summary>
		/// The number of segments to use to draw circles.
		/// </summary>
		int NumCircleSegments { get; set; }

		/// <summary>
		/// draw a single point
		/// </summary>
		/// <param name="position">where to draw the point</param>
		/// <param name="color">color of the circle to draw</param>
		void Point(Vector2 position, Color color);

		/// <summary>
		/// draw a quick circle
		/// </summary>
		/// <param name="position">where to draw the circle</param>
		/// <param name="radius">radius of the desired circle</param>
		/// <param name="color">color of the circle to draw</param>
		void Circle(Vector2 position, float radius, Color color);

		/// <summary>
		/// draw a quick line
		/// </summary>
		/// <param name="start">start point</param>
		/// <param name="end">end point</param>
		/// <param name="color">color of the line to draw</param>
		void Line(Vector2 start, Vector2 end, Color color);

		/// <summary>
		/// draw a quick box
		/// </summary>
		/// <param name="upperLeft">start point</param>
		/// <param name="lowerRight">end point</param>
		/// <param name="color">color of the line to draw</param>
		void AxisAlignedBox(Vector2 upperLeft, Vector2 lowerRight, Color color);

		/// <summary>
		/// draw a quick box
		/// </summary>
		/// <param name="rect">the rectangle to draw</param>
		/// <param name="color">color of the line to draw</param>
		void Rectangle(Rectangle rect, Color color);

		/// <summary>
		/// Draw a stupid rectanlge.
		/// This is the easiest way to draw a rectangle
		/// </summary>
		/// <param name="upperLeft">start point</param>
		/// <param name="lowerRight">end point</param>
		/// <param name="scale">the scale to draw the rectangle</param>
		/// <param name="color">the color to use to draw the rectangle</param>
		void Rectangle(Vector2 upperLeft, Vector2 lowerRight, float rotation, float scale, Color color);

		/// <summary>
		/// draw a pie shape
		/// </summary>
		/// <param name="Position">location to draw the pie</param>
		/// <param name="radius">the radius of the pie</param>
		/// <param name="startAngle">the angle to start the pie</param>
		/// <param name="sweepAngle">the sweep angle of the pie</param>
		/// <param name="color">color dat pie</param>
		void Pie(Vector2 Position, float radius, float startAngle, float sweepAngle, Color color);

		/// <summary>
		/// draw a pie shape
		/// </summary>
		/// <param name="Position">location to draw the pie</param>
		/// <param name="radius">the radius of the pie</param>
		/// <param name="startAngle">the angle to start the pie</param>
		/// <param name="sweepAngle">the sweep angle of the pie</param>
		/// <param name="color">color dat pie</param>
		void SineWave(Vector2 start, Vector2 end, float frequency, float amplitude, Color color);

		/// <summary>
		/// Get/Set the thickness of the shape's edge.
		/// </summary>
		float Thickness { get; set; }
	}
}