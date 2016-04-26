using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	public Dictionary<string, int> inventory = new Dictionary<string, int>();

	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}

	void addItem(string name) {
		addItem (name, 1);
	}

	void addItem(string name, int quantity) {
		if(inventory.ContainsKey (name) ) {
			inventory [name] += quantity;
		} else {
			inventory.Add (name, quantity);
		}
	}

	void removeItem(string name) {
		removeItem (name, 1);
	}

	void removeItem(string name, int quantity) {
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
