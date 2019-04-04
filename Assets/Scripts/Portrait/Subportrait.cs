using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// A instantiable class/prefab that contains all
/// information regarding a Subportrait.
/// </summary>
public class Subportrait : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    // Character Information
    [Header("Character Information")]
    [ReadOnly] [SerializeField] private string m_name;
    [ReadOnly] [SerializeField] private bool m_isSpeaking;
    [SerializeField] private GameObject charName;
    private SubportraitTuple m_picture;


    // Subportrait Backgrounds
    [Header("Subportrait Background Sprites")]
    [SerializeField] private GameObject idleBackground;
    [SerializeField] private GameObject speakBackground;

    #endregion


    /**
	 * Modifies the data members so that they may
	 * be read-only, return specific values, or
	 * expose certain data members to the public
	 */
    #region Member Properties

    #endregion


    /**
	 * Any Unity Methods used.
	 */
    #region Unity Methods

    #endregion


    /**
	 * Constructors that are called when building
	 * the class.
	 */
    #region Constructors

    /// <summary>
    /// Constructor based off of a character's name and their respective
    /// SubportraitTuple that specifies their position on the Subportrait
    /// Character texture.
    /// </summary>
    public Subportrait(string name, SubportraitTuple subportrait)
    {
        // Set data members
        m_name = name;
        m_isSpeaking = false;
        m_picture = subportrait;

        // Set associated GameObject members
        charName.GetComponent<Text>().text = name;
    }

    #endregion


    /**
	 * Methods that are able to be called from
	 * outside of the class.
	 */
    #region Public Methods

    /// <summary>
    /// Sets the background of the Subportrait to
    /// an active or inactive state, as well as 
    /// changing the Subportraits isSpeaking bool.
    /// </summary>
    public void EnableSpeaker(bool isSpeaking)
    {
        m_isSpeaking = isSpeaking;

        if (isSpeaking)
        {
            idleBackground.SetActive(false);
            speakBackground.SetActive(true);
        }
        else
        {
            idleBackground.SetActive(true);
            speakBackground.SetActive(false);
        }
    }

	#endregion


	/**
	 * Private functions that are only used from
	 * within this class.
	 */
	#region Member Functions

	#endregion
}
