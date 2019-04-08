using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Primary controller for the dialogue system.
/// </summary>
public class DialogueManager : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    [Header("File Path")]
    [Tooltip("Requires standard file formatting excluding the file name (./Assets/folder/)")]
    [SerializeField] private string filePath;
    [Tooltip("Requires the file name and extension given the path above")]
    public string fileName;
    private string path;

    private Queue<DialogueTuple> dialogueQueue = new Queue<DialogueTuple>();

    [Header("Dialogue Boxes")]
    [Tooltip("The \"Visual Novel\" style UI Dialogue GameObject")]
    [SerializeField] private GameObject VNDialogueBox;
    [Tooltip("The \"Vindictus (Nexon)\" style UI Dialogue GameObject")]
    [SerializeField] private GameObject NXDialogueBox;
    private Text VNDialogueBoxCharName;
    private Text VNDialogueBoxText;
    private Text NXDialogueBoxCharName;
    private Text NXDialogueBoxText;

    [Header("Text Options")]
    [Tooltip("The delay used between the reveal of the characters in the " +
        "dialogue box")]
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

        // Initialize text components for VN UI
        Text[] VNChildren = VNDialogueBox.GetComponentsInChildren<Text>();
        VNDialogueBoxCharName = VNChildren[0];
        VNDialogueBoxText     = VNChildren[1];

        // Initialize text components for NX UI
        NXDialogueBoxText = NXDialogueBox.GetComponentsInChildren<Text>()[0];
    }

    private void Start()
    {
        // Initialize parser
        TextParser.ReadFileIntoQueue(path, ref dialogueQueue);

        // Start dialogue
        StartCoroutine(RevealDialogue(VNDialogueBoxCharName, VNDialogueBoxText));
    }

    #endregion


    /**
	 * Private functions that are only used from
	 * within this class.
	 */
    #region Member Functions

    /// <summary>
    /// Reveals text is a typewriter-like fashion, and
    /// requires the player to press any key to move on
    /// to the next piece of dialogue in the queue.
    /// </summary>
    private IEnumerator RevealDialogue(Text dialogueBoxCharName, Text dialogueBoxText)
    {
        // Continue to go through dialogue queue until empty
        while (dialogueQueue.Count > 0)
        {
            // Dequeue and label dialogue box with character's
            // name
            DialogueTuple tuple = dialogueQueue.Dequeue();
            dialogueBoxCharName.text = tuple.name;

            // Typewriter animation
            for (int i = 0; i <= tuple.dialogue.Length; ++i)
            {
                // Check if user inputted an action to skip the
                // animation of the dialogue
                if (Input.anyKeyDown)
                {
                    dialogueBoxText.text = tuple.dialogue;
                    yield return new WaitForSeconds(.5f);
                    break;
                }

                string currentText = tuple.dialogue.Substring(0, i);
                dialogueBoxText.text = currentText;
                yield return new WaitForSeconds(scrollDelay);
            }

            // Wait for user input before moving onto next
            // dialogue
            while (!Input.anyKey)
                yield return new WaitForSeconds(.05f);
        }
    }

    #endregion
}
