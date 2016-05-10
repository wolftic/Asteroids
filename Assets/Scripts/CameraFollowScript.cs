using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	
	public Transform player;
	public Vector3 offset;
	public KeyCode left, right;

	private float yRotation;
	[SerializeField]
	private float ySpeed;

	void Start () {
		transform.GetChild(0).localPosition = offset;
	}

	void Update () {
		if(player)
		{
			if (Input.GetKey (left)) {
				yRotation += Time.deltaTime * ySpeed;
			} else if (Input.GetKey (right)) {
				yRotation -= Time.deltaTime * ySpeed;
			}
			transform.rotation = Quaternion.Euler (0, yRotation, 0);
			transform.position = player.position;
		}
	}
}
