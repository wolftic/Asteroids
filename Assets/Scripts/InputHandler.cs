using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {


	Dictionary<string, KeyCode> inputs = new Dictionary<string, KeyCode> ();

	void Start(){
		inputs.Add (camLeft, KeyCode.Q);
		inputs.Add (camRight, KeyCode.E);
		inputs.Add (pauzeKnop, KeyCode.Escape);
		inputs.Add (shootKnop, KeyCode.Space);
		inputs.Add (reloadKnop, KeyCode.R);
		inputs.Add (forwardKnop, KeyCode.W);
		inputs.Add (leftKnop, KeyCode.A);
		inputs.Add (downKnop, KeyCode.S);
		inputs.Add (rightKnop, KeyCode.D);
	}
}
