using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Bullet projectile;
	public Transform muzzle;
	public float shootDelay;
	public float bulletSpeed;
	public float fireRate = 0.8F;
	public AudioClip shotSound1;
	public AudioClip shotSound2;

	private float nextFire = 0.0F;
	private float bullets = 10;
	private float reloadTime = 1.5F;

	void Update()
	{
		if(bullets > 0 && Time.time > nextFire && Input.GetMouseButton (0))
		{
			Shoot();
		}
		else if(bullets < 10 && Input.GetKey ("r"))
		{
			Reload();
		}
	}

	private void Shoot ()
	{
		Bullet bullet = Instantiate (projectile, muzzle.position, muzzle.rotation) as Bullet;
		bullets -= 1;
		nextFire = nextFire + fireRate;
	}

	private void Reload()
	{
		bullets = 10;
		nextFire = nextFire + reloadTime;
	}

}
