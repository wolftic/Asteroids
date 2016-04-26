using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Canvas startMenu;
	public Canvas optionMenu;
	public Canvas tutorialMenu;
	public Canvas creditsMenu;
	public Canvas planetMenu;
	public Canvas shopMenu;

	void Awake()
	{
		startMenu = startMenu.GetComponent <Canvas>();
		optionMenu = optionMenu.GetComponent <Canvas>();
		tutorialMenu = tutorialMenu.GetComponent <Canvas> ();
		creditsMenu = creditsMenu.GetComponent <Canvas> ();
		planetMenu = planetMenu.GetComponent <Canvas> ();
		shopMenu = shopMenu.GetComponent <Canvas> ();

		startMenu.enabled = true;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
	}

	public void TutorialScherm()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = true;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
	}

	public void NewGame(string scene)
	{
		SceneManager.LoadScene (scene);
	}

	public void OptionMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = true;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
	}

	public void ExitOptions()
	{
		startMenu.enabled = true;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
	}

	public void CreditMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = true;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
	}

	public void PlanetSelection()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = true;
		shopMenu.enabled = false;
	}

	public void ShopMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = true;
	}
}
