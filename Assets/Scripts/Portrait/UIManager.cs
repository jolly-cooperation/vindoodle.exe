using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



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
    private static SubportraitTexture m_subportraitTexture = new SubportraitTexture();

    // UI Canvas
    [Header("UI Canvas Objects")]
    [Tooltip("The \"Visual Novel\" style UI Canvas GameObject")]
    [SerializeField] private GameObject VNCanvas;
    [Tooltip("The \"Vindictus (Nexon)\" style UI Canvas GameObject")]
    [SerializeField] private GameObject NXCanvas;

    // Primary portrait and Subportrait members
    [Header("Main Portrait")]
    [Tooltip("The primary portrait that displays a sprite that is " +
        "at the forefront of the scene (to show who is talking)")]
    [SerializeField] private GameObject mainPortrait;

    [Header("Subportraits")]
    [Tooltip("Prefab for the subportrait GameObject, allows for " +
        "dynamic spawning of subportraits")]
    [SerializeField] private GameObject subportraitPrefab;
    [Tooltip("Keeps track of the total amount of instantiated subportrait " +
    "amount")]
    [ReadOnly] [SerializeField] private int activeSubportraitCount = 0;
    [Tooltip("[WIP] The list of subportraits in a scene")]
    public List<GameObject> subportraitList;

    // Background members
    [Header("Backgrounds")]
    [Tooltip("Requires \"Resource Path\" formatting (folder/file) " +
        "instead of normal file formatting (./Assets/folder/file.ext)")]
    [SerializeField] private string bgResourcePath;
    [Tooltip("The GameObject that holds the background of the scene")]
    [SerializeField] private GameObject background;

    // Speaking character members
    private GameObject currentSpeaker;
    private GameObject lastSpeaker;

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

    /// <summary>
    /// Sets the Main Portrait Sprite to another
    /// character. It is recommended to use the
    /// CharEnum for clarity, but defaults to an
    /// integer.
    /// </summary>
    public void SetMainPortrait(int character)
    {
        mainPortrait.GetComponent<Image>().sprite = characterPortraits[character];
    }

    /// <summary>
    /// Sets the Background Image to another 
    /// one based on the file name of the image
    /// in the Resource directory. Since the
    /// images are not precached on an object,
    /// this method may take additional time.
    /// </summary>
    public void SetBackground(string bg)
    {
        // Grabs the Resourace path and loads the .jpg file as a sprite
        string path = bgResourcePath + bg;
        background.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
    }

    /// <summary>
    /// Instantiate a new Subportrait GameObject
    /// that will contain the name as the character
    /// used as the parameter.
    /// </summary>
    public void InstantiateSubportrait(int character)
    {
        // Instantiate new Subportrait GameObject from prefab and add
        // to the subportraitList for tracking
        string characterName = ((CharEnum)character).ToString();
        GameObject subportrait = Instantiate(subportraitPrefab, VNCanvas.transform);
        subportrait.SetActive(true);
        subportraitList.Add(subportrait);
        activeSubportraitCount = subportraitList.Count;
        subportrait.GetComponent<Subportrait>().Initalize(characterName, m_subportraitTexture[character]);

        // Given how many portraits are on the list, offset the new
        // subportrait by a set offset in respect to the last subportrait's
        // position
        Vector2 xOffset = Vector2.right * 130;
        RectTransform subportraitTransform = subportrait.GetComponent<RectTransform>();

        // Modifies the position of the last spawned subportrait given
        // position and anchor scale
        if (subportraitList.Count <= 1)
        { /* Pass since origin is ok */ }
        else if (subportraitList.Count == 2)
        {
            subportraitTransform.anchoredPosition += xOffset;
        }
        else
        {
            Vector2 lastPortraitPosition = 
                subportraitList[subportraitList.IndexOf(subportrait) - 1]
                .GetComponent<RectTransform>().anchoredPosition;
            subportraitTransform.anchoredPosition = lastPortraitPosition + xOffset;
        }

        subportrait.name = "Subportrait (" + characterName + ")";
    }

    /// <summary>
    /// </summary>
    public void ChangeSpeaker()
    {
    }

    #endregion


    /**
	 * Private functions that are only used from
	 * within this class.
	 */
    #region Member Functions

    #endregion
}
