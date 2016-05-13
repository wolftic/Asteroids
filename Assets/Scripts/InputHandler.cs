﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {


	Dictionary<string, KeyCode> inputs = new Dictionary<string, KeyCode> ();
	float horizontal, vertical;

	void Start(){
		inputs.Add ("camLeft", KeyCode.Q);
		inputs.Add ("camRight", KeyCode.E);
		inputs.Add ("pauzeKnop", KeyCode.Escape);
		inputs.Add ("shootKnop", KeyCode.Space);
		inputs.Add ("reloadKnop", KeyCode.R);
		inputs.Add ("forwardKnop", KeyCode.W);
		inputs.Add ("leftKnop", KeyCode.A);
		inputs.Add ("breakKnop", KeyCode.S);
		inputs.Add ("rightKnop", KeyCode.D);
	}
		
	public void ChangeKey(string key){
		StartCoroutine (checkkey(key));
	}

	void Update() {

		if (Input.GetKey (inputs["leftKnop"])) {
			if (horizontal >= 1)
				return;
			horizontal -= Time.deltaTime * 3;
		} else if (Input.GetKey (inputs["rightKnop"])) {
			if (horizontal <= -1)
				return;
			horizontal += Time.deltaTime * 3;
		} else {
			horizontal = Mathf.Lerp (0, horizontal, Time.deltaTime * 3);
		}

		if (Input.GetKey (inputs["forwardKnop"])) {
			if (vertical >= 1)
				return;
			vertical += Time.deltaTime * 3;
		} else if (Input.GetKey (inputs["breakKnop"])) {
			if (vertical <= -1) return;
			vertical -= Time.deltaTime * 3;

		} else {
			vertical = Mathf.Lerp (0, vertical, Time.deltaTime * 3);
		}

		horizontal = Mathf.Clamp (horizontal, -1, 1);
		vertical = Mathf.Clamp (vertical, -1, 1);

		Debug.Log (GetAxis ("horizontal") + " | " + GetAxis ("vertical"));
	}

	public float GetAxis(string axis) {
		switch (axis) {
		case "horizontal":
			return horizontal;
			break;
		case "vertical":
			return vertical;
			break;
		default:
			return 0;
			break;
		}
	}

	IEnumerator checkkey(string key){
		yield return new WaitUntil (() => (FetchKey () != KeyCode.None));
		inputs[key] = FetchKey();
	}

	KeyCode FetchKey()
	{
		int e = System.Enum.GetNames (typeof(KeyCode)).Length;
		for (int i = 0; i < e; i++) {
			if (Input.GetKey ((KeyCode)i)) {
				Debug.Log ((KeyCode)i);
				return (KeyCode)i;
			}
		}

		return KeyCode.None;
	}

}
