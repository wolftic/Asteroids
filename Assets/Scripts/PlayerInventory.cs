using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	public enum ItemType { SSEngalica, SCStriker, Gun1, AmmoGun1, Gun2, AmmoGun2, SpeedUpgrade, HealthUpgrade, FirePowerUpgrade, EnemyScrap, CometScrap};
	public Dictionary<ItemType, int> inventory = new Dictionary<ItemType, int>();

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

	public void addItem(ItemType name) {
		addItem (name, 1);
	}

	void addItem(ItemType name, int quantity) {
		if(inventory.ContainsKey (name) ) {
			inventory [name] += quantity;
		} else {
			inventory.Add (name, quantity);
		}
	}

	void removeItem(ItemType name) {
		removeItem (name, 1);
	}

	void removeItem(ItemType name, int quantity) {
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
