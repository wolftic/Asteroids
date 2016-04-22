using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {

	public Canvas startMenu;
	public Canvas optionMenu;
	public Canvas tutorialMenu;
	public Canvas creditsMenu;
	public Canvas planetMenu;

	void Awake()
	{
		startMenu = startMenu.GetComponent <Canvas>();
		optionMenu = optionMenu.GetComponent <Canvas>();
		tutorialMenu = tutorialMenu.GetComponent <Canvas> ();
		creditsMenu = creditsMenu.GetComponent <Canvas> ();
		planetMenu = planetMenu.GetComponent <Canvas> ();

		startMenu.enabled = true;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
	}

	public void TutorialScherm()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = true;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
	}

	public void NewGame()
	{
		SceneManager.LoadScene ("scene");
	}

	public void OptionMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = true;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
	}

	public void ExitOptions()
	{
		startMenu.enabled = true;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
	}

	public void CreditMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = true;
		planetMenu.enabled = false;
	}

	public void PlanetSelection()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = true;
	}
}
