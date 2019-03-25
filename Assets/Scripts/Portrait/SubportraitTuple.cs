public class SubportraitTuple
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    public double uvX;
    public double uvY;

    #endregion


    /**
	 * Constructors that are called when building
	 * the class.
	 */
    #region Constructors

    public SubportraitTuple(double newX, double newY)
    {
        // Clamp x value
        if (newX >= 0 && newX <= 1)
        {
            uvX = newX;
        }
        else
        {
            uvX = (newX < 0) ? 0 : 1;
        }

        // Clamp y value
        if (newY >= 0 && newY <= 1)
        {
            uvY = newY;
        }
        else
        {
            uvY = (newY < 0) ? 0 : 1;
        }
    }

    #endregion
}
