using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	
	public Transform player;
	Vector3 offset;

	void Start () {
		offset = transform.position;
	}

	void Update () {
		transform.position = Vector3.Lerp (transform.position, player.position + offset, 5f * Time.deltaTime);
	}
}
