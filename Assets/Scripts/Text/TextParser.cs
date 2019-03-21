using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class TextParser : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

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

    public void ReadFileIntoQueue(string path, ref List<string> queue)
    {
        if (!File.Exists(path))
            throw new FileLoadException("Dialogue file (" + path + ") does not exist");

        // Tries to use StreamReader to read the file (catches exceptions if
        // it fails)
        try
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string fileLine;

                // Adds read file line (up to newline) and pushbacks to
                // the queue
                while ((fileLine = reader.ReadLine()) != null)
                    queue.Add(fileLine);
            }
        }
        catch (IOException e)
        {
            Debug.Log("[TEXT_PARSER] Line could not be read");
            Debug.Log(e.Message);
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
