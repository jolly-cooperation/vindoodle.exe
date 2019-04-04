/// <summary>
/// A simple container that holds the UV values of
/// a character's position in the Subportrait Character
/// texture (ReadOnly).
/// </summary>
public class SubportraitTuple
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    private double x;
    private double y;

    public double uvX { get { return x; } set { return; } }
    public double uvY { get { return y; } set { return; } }

    #endregion


    /**
	 * Constructors that are called when building
	 * the class.
	 */
    #region Constructors

    /// <summary>
    /// Construction based on the UV x and y positions. Only
    /// constructs in the range [0, 1].
    /// </summary>
    public SubportraitTuple(double newX, double newY)
    {
        // Clamp x value
        if (newX >= 0 && newX <= 1)
        {
            x = newX;
        }
        else
        {
            x = (newX < 0) ? 0 : 1;
        }

        // Clamp y value
        if (newY >= 0 && newY <= 1)
        {
            y = newY;
        }
        else
        {
            y = (newY < 0) ? 0 : 1;
        }
    }

    #endregion
}
