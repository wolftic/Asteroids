using UnityEngine;
using System.Collections;

public class CometSpawner : MonoBehaviour {
	public Transform comet;
	public float spawnDelay;
	public float radius;
	private float spawnTime;

	void Start () {
	
	}

	void Update () {
		if (spawnTime < Time.time) {
			spawnTime = Time.time + spawnDelay;
			//

			Vector3 random = Random.insideUnitSphere;
			random.y = 0;
			Vector3 position = random * radius;

			Quaternion rotation = Quaternion.Euler (0, Random.Range (0, 359), 0);

			SpawnComet(position, rotation);
		}
	}

	void SpawnComet (Vector3 position, Quaternion rotation) {
		Instantiate (comet, position, rotation);
	}
}
