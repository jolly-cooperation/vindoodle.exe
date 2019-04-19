using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// A instantiable class/prefab component 
/// that contains all information 
/// regarding a Subportrait.
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
    [SerializeField] private GameObject portrait;
    private SubportraitTuple m_picture;
    private int m_charID;

    // Subportrait Backgrounds
    [Header("Subportrait Background Sprites")]
    [SerializeField] private GameObject idleBackground;
    [SerializeField] private GameObject speakBackground;

    // Additional Options
    [Header("Additional Options")]
    [SerializeField] [Slider(0.0f, 1.0f)] private float notSpeakingAlphaLevel;

    #endregion


    /**
	 * Modifies the data members so that they may
	 * be read-only, return specific values, or
	 * expose certain data members to the public
	 */
    #region Member Properties

    /// <summary>
    /// The name of the character.
    /// </summary>
    public string Name { get { return m_name; } }

    /// <summary>
    /// The GameObject that displays the character's
    /// name.
    /// </summary>
    public GameObject CharName { get { return charName; } }

    /// <summary>
    /// The ID of the character (CharID).
    /// </summary>
    public int CharID { get { return m_charID; } }

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

    #endregion


    /**
	 * Methods that are able to be called from
	 * outside of the class.
	 */
    #region Public Methods

    /// <summary>
    /// A pseudo-constructor based off of a character's name and their respective
    /// SubportraitTuple that specifies their position on the Subportrait
    /// Character texture. Called with the same parameters as a normal constructors,
    /// but should be called after instantiating an instance of this object (given
    /// that the object is a prefab).
    /// </summary>
    public void Initalize(int character, SubportraitTuple subportrait)
    {
        // Set data members
        m_charID = character;
        m_name = ((CharID)character).ToString();
        m_isSpeaking = false;
        m_picture = subportrait;

        // Set associated GameObject members
        charName.GetComponent<Text>().text = name;
        GetComponent<CanvasGroup>().alpha = notSpeakingAlphaLevel;
        portrait.GetComponent<RawImage>().uvRect = 
            new Rect((float)m_picture.uvX, (float)m_picture.uvY, 
            portrait.GetComponent<RawImage>().uvRect.width, 
            portrait.GetComponent<RawImage>().uvRect.height);
    }

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
            GetComponent<CanvasGroup>().alpha = 1.0f;
        }
        else
        {
            idleBackground.SetActive(true);
            speakBackground.SetActive(false);
            GetComponent<CanvasGroup>().alpha = .5f;
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
