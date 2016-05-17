using UnityEngine;
using System.Collections;

public class PauzeScript : MonoBehaviour {

	private InputHandler inputHandler;

	void Awake(){
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
	}

	void Update()
	{
		if(Input.GetKeyDown (inputHandler.inputs["pauzeKnop"]) && Time.timeScale == 1)
		{
			Time.timeScale = 0;
		} else if(Input.GetKeyDown (inputHandler.inputs["pauzeKnop"]) && Time.timeScale == 0){
			Time.timeScale = 1;
		}
	}
}
