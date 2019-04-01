public class DialogueTuple
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    public string name;
    public string dialogue;

    #endregion


    /**
	 * Constructors that are called when building
	 * the class.
	 */
    #region Constructors

    public DialogueTuple(string newName, string newDialogue)
    {
        name     = newName;
        dialogue = newDialogue;
    }

	#endregion

}
