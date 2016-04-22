using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public float Health;

	public void doDamage(float damage) 
	{
		Health -= damage;
	}

	void Update()
	{
		if(Health <= 0)
		{
			Destroy (gameObject);
		}
	}
}
