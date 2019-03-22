using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    [Header("File Path")]
    [SerializeField] private string filePath;
    public string fileName;
    private string path;

    private List<string> dialogueQueue = new List<string>();

    [Header("Dialogue Boxes")]
    [SerializeField] private GameObject VNDialogueBox;
    [SerializeField] private GameObject NXDialogueBox;
    private Text VNDialogueBoxText;
    private Text NXDialogueBoxText;

    [Header("Text Options")]
    [SerializeField] private float scrollDelay;

    #endregion


    /**
	 * Any Unity Methods used.
	 */
    #region Unity Methods

    private void Awake()
    {
        // Initialize file path
        path = filePath + fileName;

        // Initialize text components
        VNDialogueBoxText = VNDialogueBox.GetComponentInChildren<Text>();
        NXDialogueBoxText = NXDialogueBox.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        // Initialize parser
        TextParser.ReadFileIntoQueue(path, ref dialogueQueue);

        // Start dialogue
        StartCoroutine(RevealDialogue(VNDialogueBoxText));
    }

    #endregion


    /**
	 * Private functions that are only used from
	 * within this class.
	 */
    #region Member Functions

    // Reveals text is a typewriter-like fashion, and
    // requires the player to press any key to move on
    // to the next piece of dialogue in the queue
    private IEnumerator RevealDialogue(Text dialogueBoxText)
    {
        foreach (string dialogue in dialogueQueue)
        {
            for (int i = 0; i <= dialogue.Length; ++i)
            {
                string currentText = dialogue.Substring(0, i);
                dialogueBoxText.text = currentText;
                yield return new WaitForSeconds(scrollDelay);
            }
            while (!Input.anyKey)
                yield return new WaitForSeconds(.05f);
        }
    }

    #endregion
}
