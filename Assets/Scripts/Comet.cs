using UnityEngine;
using System.Collections;

public class Comet : MonoBehaviour {

	public enum CometType
	{
		BIG,
		MIDDLE,
		SMALL
	}

	public CometType cometType;

	void Start () {
		transform.tag = "Comet";
		UpdateScale ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Split ();
		}

		transform.Translate (Vector3.up * Time.deltaTime);
	}

	public void UpdateScale () {
		if (cometType == CometType.BIG) {
			transform.localScale = new Vector2 (2, 2);
		} else if(cometType == CometType.MIDDLE) {
			transform.localScale = new Vector2 (1, 1);
		} else {
			transform.localScale = new Vector2 (.5f, .5f);
		}
	}

	public void Split () {
		if (cometType != CometType.SMALL) {
			for(int i = 0; i < 2; i++) {
				Comet comet = Instantiate (Resources.Load ("Comets/Comet", typeof(Comet)), transform.position, Quaternion.Euler (0, 0, Random.Range (0, 360))) as Comet;
				comet.cometType = (cometType == CometType.BIG) ? CometType.MIDDLE : CometType.SMALL;
				comet.UpdateScale ();
			}
		}

		Destroy (gameObject);
	}
}
