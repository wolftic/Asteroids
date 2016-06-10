using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	
	public Transform player;
	public Vector3 offset;
	public KeyCode left, right;
	public bool BackCam = false;

	private float yRotation;
	[SerializeField]
	private float ySpeed;
	private InputHandler inputHandler;

	void Awake(){
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Start () {
		transform.GetChild(0).localPosition = offset;
	}

	void Update () {
		if(player)
		{
			/*if (Input.GetKey (inputHandler.inputs["camLeft"])) {
				yRotation += Time.deltaTime * ySpeed;
			} else if (Input.GetKey (inputHandler.inputs["camRight"])) {
				yRotation -= Time.deltaTime * ySpeed;
			}*/
			yRotation = player.eulerAngles.y;

			if (Input.GetKey(inputHandler.inputs["watchBehindKnop"])) {
				yRotation += 180;
			}

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (0, yRotation, 0), 5.0f * Time.deltaTime);
			transform.position = player.position;
		}
	}
}