using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;



/// <summary>
/// Primary controller for the UI.
/// </summary>
public class UIManager : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    // Access to all Character Sprites
    [Header("Character Sprites")]
    [Tooltip("[WIP] Pre-cached sprites that are used to change " +
        "who is at the forefront of the scene")]
    [SerializeField] private Sprite[] characterPortraits;

    // Subportrait singleton for easy indexing
    private static SubportraitTexture m_subportraitTexture;

    // Primary portrait and Subportrait members
    [Header("Main Portrait")]
    [Tooltip("The primary portrait that displays a sprite that is " +
        "at the forefront of the scene (to show who is talking)")]
    [SerializeField] private GameObject mainPortrait;

    [Header("Subportraits")]
    [Tooltip("Prefab for the subportrait GameObject, allows for " +
        "dynamic spawning of subportraits")]
    [SerializeField] private GameObject subPortraitPrefab;
    [Tooltip("[WIP] The list of subportraits in a scene")]
    public List<GameObject> subportraitList;

    // Background members
    [Header("Backgrounds")]
    [Tooltip("Requires \"Resource Path\" formatting (folder/file) " +
        "instead of normal file formatting (./Assets/folder/file.ext)")]
    [SerializeField] private string bgResourcePath;
    [Tooltip("The GameObject that holds the background of the scene")]
    [SerializeField] private GameObject background;

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

    // Use with intention of BGEnum
    public void SetBackground(string bg)
    {
        // Grabs the Resourace path and loads the .jpg file as a sprite
        string path = bgResourcePath + bg;
        background.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
    }

	#endregion


	/**
	 * Private functions that are only used from
	 * within this class.
	 */
	#region Member Functions

	#endregion
}
