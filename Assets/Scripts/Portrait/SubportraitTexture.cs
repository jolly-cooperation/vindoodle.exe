/// <summary>
/// Container that holds all of the UV positions based
/// on the CharEnum. Use as a static Singleton.
/// </summary>
public class SubportraitTexture 
{
    /**
     * Holds all the data members that the class
     * contains.
     */
    #region Data Members

    /// <summary>
    /// All the characters UV coordinate positions on the subportrait texture
    /// which is reflective of the CharEnum
    /// Kirstie,         Gallagher,      Ferghus,        Tieve,
    /// Mysterious Man,  Brynn,          Clodagh,        Ceara,
    /// Gwynn,           Marrec,         Aodhan
    /// </summary>
    private SubportraitTuple[] m_characters = new SubportraitTuple[11] {
            new SubportraitTuple(0.00,0.67), new SubportraitTuple(0.25,0.67), new SubportraitTuple(0.50,0.67), new SubportraitTuple(0.75,0.67),
            new SubportraitTuple(0.00,0.34), new SubportraitTuple(0.25,0.34), new SubportraitTuple(0.50,0.34), new SubportraitTuple(0.75,0.34),
            new SubportraitTuple(0.00,0.00), new SubportraitTuple(0.25,0.00), new SubportraitTuple(0.50,0.00) };

    #endregion

    /**
	 * Methods that are able to be called from
	 * outside of the class.
	 */
    #region Public Methods

    /// <summary>
    /// Indexer that supports indexing by CharEnum and by normal
    /// int (ReadOnly).
    /// </summary>
    public SubportraitTuple this[int i]
    {
        get { return m_characters[i]; }
        set { return; }
    }

	#endregion

}
