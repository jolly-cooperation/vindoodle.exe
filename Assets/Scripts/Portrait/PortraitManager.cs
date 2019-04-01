using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PortraitManager : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    // Access to all Character Sprites
    [Header("Character Sprites")]
    [SerializeField] private Sprite[] characterPortraits;

    // Subportrait singleton for easy indexing
    private static SubportraitTexture m_subportraitTexture;

    [Header("Main Portrait")]
    [SerializeField] private GameObject mainPortrait;

    [Header("Subportraits")]
    public List<GameObject> subportraitList;

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

    #endregion


    /**
	 * Methods that are able to be called from
	 * outside of the class.
	 */
    #region Public Methods

    // Use with intention of CharEnum
    public void SetMainPortrait(int character)
    {
        mainPortrait.GetComponent<Image>().sprite = characterPortraits[character];
    }

	#endregion


	/**
	 * Private functions that are only used from
	 * within this class.
	 */
	#region Member Functions

	#endregion
}
