using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour 
{

	public Bullet projectile;
	public Transform muzzle;
	public float shootDelay;
	public float bulletSpeed;
	public float fireRate = 0.4F;
	public AudioClip shotSound1;
	public AudioClip shotSound2;

	private float nextFire = 0.0F;
	private float bullets = 12;
	private float reloadTime = 1.5F;
	private InputHandler inputHandler;

	void Awake(){
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Update()
	{
		if(bullets > 0 && Time.time > nextFire && Input.GetKey (inputHandler.inputs["shootKnop"]))
		{
			Shoot();
		}
		else if(bullets < 10 && Input.GetKey (inputHandler.inputs["reloadKnop"]))
		{
			Reload();
		}
	}

	private void Shoot ()
	{
		GameObject obj = PoolingScript.current.GetPooledObject ();

		if (obj == null)
			return;

		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);



		//Bullet bullet = Instantiate (projectile, muzzle.position, muzzle.rotation) as Bullet;
		Bullet bullet = obj.GetComponent <Bullet>();
		bullet.shooter = transform;

		bullets -= 1;
		nextFire = Time.time + fireRate;
	}

	private void Reload()
	{
		bullets = 12;
		nextFire = Time.time + reloadTime;
	}

}
