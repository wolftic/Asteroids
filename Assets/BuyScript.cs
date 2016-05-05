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
		if (playerInventory.InInventory (ItemType.SCStriker) == false)
			if (playerInventory.DeductCoins (20)) {
				playerInventory.AddItem (ItemType.SCStriker);
			} else
				Debug.Log ("Get More Moneyz");
			else
				Debug.Log ("Already got it");
	}

	public void BuyGun1()
	{
		if(playerInventory.InInventory (ItemType.Gun1) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.Gun1);
				Debug.Log ("Bought Gun1");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyAmmoGun1()
	{
		if (playerInventory.DeductCoins (10)) {
			playerInventory.AddItem (ItemType.AmmoGun1);
			Debug.Log ("bought ammo");
		} else
			Debug.Log ("get more money");
	}

	public void BuyGun2()
	{
		if(playerInventory.InInventory (ItemType.Gun2) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.Gun2);
				Debug.Log ("Bought Gun2");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyAmmoGun2()
	{
		if (playerInventory.DeductCoins (10)) {
			playerInventory.AddItem (ItemType.AmmoGun2);
			Debug.Log ("bought ammo");
		} else
			Debug.Log ("get more money");
		}

	public void BuyUpgradeSpeed()
	{
		if(playerInventory.InInventory (ItemType.SpeedUpgrade) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.SpeedUpgrade);
				Debug.Log ("Bought speed upgrade");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyUpgradeHealth()
	{
		if(playerInventory.InInventory (ItemType.HealthUpgrade) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.HealthUpgrade);
				Debug.Log ("Bought health upgrade");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
	}

	public void BuyUpgradeFirepower()
	{
		if(playerInventory.InInventory (ItemType.FirePowerUpgrade) == false)
		{
			if(playerInventory.DeductCoins (20))
			{
				playerInventory.AddItem (ItemType.FirePowerUpgrade);
				Debug.Log ("Bought firepower upgrade");
			}
			else
			{
				Debug.Log ("Get More moneyz");
			}
		}
		else
			Debug.Log ("Already got it!");
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
