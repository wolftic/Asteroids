using UnityEngine;
using System.Collections;
using ItemType = PlayerInventory.ItemType;

public class BuyScript : MonoBehaviour {

	private PlayerInventory playerInventory;

	void Awake()
	{
		playerInventory = GameObject.FindGameObjectWithTag ("Playerinventory").GetComponent <PlayerInventory>();
	}

	//buy functions

	public void BuySSEngalica()
	{
		if(playerInventory.InInventory (ItemType.SSEngalica) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.SSEngalica);
				Debug.Log ("Bought SSEngalica");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuySCStriker()
	{
		if (playerInventory.DeductCoins (20)) {
			playerInventory.AddItem (ItemType.SCStriker);
		} else
			Debug.Log ("Get More Moneyz");
	}

	public void BuyGun1()
	{
		if(true)
		{

		}
	}

	public void BuyAmmoGun1()
	{
		if(playerInventory.coins >= 10)
		{

		}
	}

	public void BuyGun2()
	{
		if(true)
		{

		}
	}

	public void BuyAmmoGun2()
	{
		if(true)
		{

		}
	}

	public void BuyUpgradeSpeed()
	{
		if(true)
		{

		}
	}

	public void BuyUpgradeHealth()
	{
		if(true)
		{

		}
	}

	public void BuyUpgradeFirepower()
	{
		if(true)
		{

		}
	}

	//sell functions

	public void SellAmmoGun1()
	{
		if(true)
		{
			
		}
	}

	public void SellAmmoGun2()
	{
		if(true)
		{

		}
	}

	public void SellEnemyScrap()
	{
		if(true)
		{

		}
	}

	public void SellCometScrap()
	{
		if(true)
		{

		}
	}

}
