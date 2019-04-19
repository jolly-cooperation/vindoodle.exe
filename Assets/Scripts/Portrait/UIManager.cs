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
    private GameObject currentSpeaker = null;
    private GameObject lastSpeaker = null;

    // DEBUG
    private int DEBUG_charID_index = 0;

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
    /// CharID for clarity, but defaults to an
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
        GameObject subportrait = Instantiate(subportraitPrefab, VNCanvas.transform);
        subportrait.SetActive(true);
        subportraitList.Add(subportrait);
        activeSubportraitCount = subportraitList.Count;
        Subportrait currentSubportrait = subportrait.GetComponent<Subportrait>();
        currentSubportrait.Initalize(character, m_subportraitTexture[character]);

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
        
        // Sets the name of the GameObject itself (inspector) and in-game (CharName)
        subportrait.name = "Subportrait (" + currentSubportrait.Name + ")";
        currentSubportrait.CharName.GetComponent<Text>().text = currentSubportrait.Name;
    }

    /// <summary>
    /// Removes a Subportrait from the Subportrait List
    /// given the character's CharID.
    /// </summary>
    public void RemoveSubportraitByCharacter(int character)
    {
        int index = FindIndexForSubportrait(character);

        GameObject subportrait = subportraitList[index-1];
        subportraitList.RemoveAt(index-1);
        Destroy(subportrait);
        activeSubportraitCount = subportraitList.Count;
    }

    /// <summary>
    /// Removes a Subportrait from the Subportrait List
    /// given the character's position on the list.
    /// </summary>
    public void RemoveSubportraitByIndex(int index)
    {
        GameObject subportrait = subportraitList[index];
        subportraitList.RemoveAt(index);
        Destroy(subportrait);
        activeSubportraitCount = subportraitList.Count;
    }

    /// <summary>
    /// Effectively activates the passed in character
    /// and deactivates the previous character.
    /// Calls the EnableSpeaker method on the current
    /// character passing True, while also calling the
    /// same method on the previous subportrait passing
    /// False. 
    /// </summary>
    public void ChangeSpeaker(int character)
    {
        lastSpeaker = currentSpeaker;
        int nextSpeakerIndex = FindIndexForSubportrait(character);

        currentSpeaker = subportraitList[nextSpeakerIndex];
        currentSpeaker.GetComponent<Subportrait>().EnableSpeaker(true);
        lastSpeaker.GetComponent<Subportrait>().EnableSpeaker(false);
    }

    // DEBUG PURPOSES ONLY
    public void DEBUG_Create_Char_And_Iterate()
    { InstantiateSubportrait(DEBUG_charID_index); DEBUG_charID_index = (++DEBUG_charID_index % 11); }

    public void DEBUG_Delete_Char_And_Deiterate()
    { RemoveSubportraitByCharacter(DEBUG_charID_index); DEBUG_charID_index = (DEBUG_charID_index >= 0) ? DEBUG_charID_index-- : 0; }

    public void DEBUG_Delete_Char_At_0()
    { RemoveSubportraitByIndex(0); }

    #endregion


    /**
	 * Private functions that are only used from
	 * within this class.
	 */
    #region Member Functions

    /// <summary>
    /// Given the character's enumeration (or int), 
    /// the function returns the index in which the 
    /// Subportrait GameObject can be found in the 
    /// Subportrait List.
    /// </summary>
    private int FindIndexForSubportrait(int character)
    {
        int index = 0;

        // Iterate through subportrait list to find character
        foreach (GameObject subportraitGameObject in subportraitList)
        {
            if (subportraitGameObject.GetComponent<Subportrait>().CharID == character)
            {
                return index;
            }

            index++;
        }

        return index;
    }

    /// <summary>
    /// Modifies the position of the subportraits 
    /// to better reflect the order they're in in 
    /// the list.
    /// </summary>
    private void UpdateSubportraits()
    {
        // Given how many portraits are on the list, offset the new
        // subportrait by a set offset in respect to the last subportrait's
        // position
        Vector2 xOffset = Vector2.right * 130;
        //RectTransform subportraitTransform = subportrait.GetComponent<RectTransform>();

        // Modifies the position of the last spawned subportrait given
        // position and anchor scale
        if (subportraitList.Count <= 1)
        { /* Pass since origin is ok */ }
        else if (subportraitList.Count == 2)
        {
            //subportraitTransform.anchoredPosition += xOffset;
        }
        else
        {
            //Vector2 lastPortraitPosition =
            //    subportraitList[subportraitList.IndexOf(subportrait) - 1]
            //    .GetComponent<RectTransform>().anchoredPosition;
            //subportraitTransform.anchoredPosition = lastPortraitPosition + xOffset;
        }
    }

    #endregion
}
