using UnityEngine;
using System.Collections;

public class ShopMenuScript : MonoBehaviour {

	public Canvas buyMenu;
	public Canvas sellMenu;

	void Awake () {
	
		buyMenu = buyMenu.GetComponent <Canvas> ();
		sellMenu = sellMenu.GetComponent <Canvas> ();

		buyMenu.enabled = true;
		sellMenu.enabled = false;
	}

	public void SelectBuyMenu()
	{
		buyMenu.enabled = true;
		sellMenu.enabled = false;
	}

	public void SelectSellMenu()
	{
		buyMenu.enabled = false;
		sellMenu.enabled = true;
	}
}
