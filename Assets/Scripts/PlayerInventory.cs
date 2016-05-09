using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	public enum ItemType { SSEngalica, SCStriker, Gun1, AmmoGun1, Gun2, AmmoGun2, SpeedUpgrade, HealthUpgrade, FirePowerUpgrade, EnemyScrap, CometScrap, BrokenGuns, Bolts, 
		Minerals, Glass, RustySteelPlates, Stars};
	public Dictionary<ItemType, int> inventory = new Dictionary<ItemType, int>();

	[HideInInspector]
	public int coins = 0;

	void Start()
	{
		DontDestroyOnLoad (gameObject);
		Invoke ("CoinsDebug", 1f);
	}

	void CoinsDebug()
	{
		
		Debug.Log (coins);
		coins += 1;
		Invoke ("CoinsDebug", 0.5f);
	}

	public bool DeductCoins(int amount) {
		if (this.coins >= amount) {
			coins -= amount;
			return true;
		} else return false;
	}

	public bool DeductItem(ItemType name) {
		if (InInventory (name)) {
			RemoveItem (name);
			return true;
		} else return false;
	}

	public bool InInventory(ItemType name)
	{
		if(inventory.ContainsKey (name) )
		{
			if (inventory[name] > 0)
				return true;
		}
		return false;
	}

	public void AddItem(ItemType name) {
		AddItem (name, 1);
	}

	void AddItem(ItemType name, int quantity) {
		if(inventory.ContainsKey (name) ) {
			inventory [name] += quantity;
		} else {
			inventory.Add (name, quantity);
		}
	}

	public void RemoveItem(ItemType name) {
		RemoveItem (name, 1);
	}

	void RemoveItem(ItemType name, int quantity) {
		if(inventory.ContainsKey (name) ) {
			inventory [name] -= quantity;
			if (inventory[name] <= 0) {
				inventory.Remove (name);
			}
		} else {
			inventory.Remove (name);
		}
	}
}
