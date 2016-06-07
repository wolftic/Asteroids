using UnityEngine;
using System.Collections;

public class ShopMenuScript : MonoBehaviour {

	public Canvas buyMenu;
	public Canvas sellMenu;

	public PlayerInventory playerInventory;

	void Start()
	{
		if(GameObject.FindGameObjectWithTag ("Playerinventory") == null)
		{
			Instantiate (playerInventory);
		}
	}
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

	public void QuitShop()
	{
		buyMenu.enabled = false;
		sellMenu.enabled = false;
	}
}
