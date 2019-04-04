using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// The primary director that contains all of the
/// managers and is the primary object that controls
/// every aspect of the game.
/// </summary>
public class GameDirector : MonoBehaviour 
{
    /**
	 * Holds all the data members that the class
	 * contains.
	 */
    #region Data Members

    [Header("Managers")]
    [Tooltip("The GameObject that controls dialogue")]
    [SerializeField] private GameObject dialogueManager;
    [Tooltip("The GameObject that controls the UI")]
    [SerializeField] private GameObject uiManager;

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

	#endregion


	/**
	 * Private functions that are only used from
	 * within this class.
	 */
	#region Member Functions

	#endregion
}
