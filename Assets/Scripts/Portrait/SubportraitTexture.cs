using UnityEngine;

/// <summary>
/// Container that holds all of the UV positions based
/// on the CharID. Use as a static Singleton.
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
    /// which is reflective of the CharID
    /// Kirstie,         Gallagher,      Ferghus,        Tieve,
    /// Mysterious Man,  Brynn,          Clodagh,        Ceara,
    /// Gwynn,           Marrec,         Aodhan
    /// </summary>
    private SubportraitTuple[] m_characters = new SubportraitTuple[11] {
            new SubportraitTuple(0.000,0.670), new SubportraitTuple(0.250,0.670), new SubportraitTuple(0.500,0.670), new SubportraitTuple(0.750,0.670),
            new SubportraitTuple(0.000,0.334), new SubportraitTuple(0.250,0.334), new SubportraitTuple(0.500,0.334), new SubportraitTuple(0.750,0.334),
            new SubportraitTuple(0.000,0.000), new SubportraitTuple(0.250,0.000), new SubportraitTuple(0.500,0.000) };

    #endregion

    /**
	 * Methods that are able to be called from
	 * outside of the class.
	 */
    #region Public Methods

    /// <summary>
    /// Indexer that supports indexing by CharID and by normal
    /// int (ReadOnly).
    /// </summary>
    public SubportraitTuple this[int i]
    {
        get { return m_characters[i]; }
    }

	#endregion

}
