using UnityEngine;
using System.Collections;

public class CameraVertical : MonoBehaviour {

	public Vector2 maxRotation = new Vector2(0,0);

	void Update () {

		float turningValue = -Input.GetAxis ("Mouse Y") * Time.deltaTime * 100;
		transform.Rotate (new Vector3 (turningValue, 0, 0));

		if (transform.localRotation.x < maxRotation.x || transform.localRotation.x > maxRotation.y) {
			transform.Rotate (new Vector3 (-turningValue, 0, 0));
		}
	}
}
