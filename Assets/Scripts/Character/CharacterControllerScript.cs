using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class CharacterControllerScript : MonoBehaviour {
	
	public float mass = 1, drag = 0.1f, jump = 1;
	public Vector2 speed = new Vector2 (1, 1), acceleration = new Vector2 (1, 1), airAcceleration = new Vector2 (1, 1);
	public Animator anim;

	CharacterController character;
	Vector3 velocity, movement;

	void Start () {
		character = GetComponent<CharacterController> ();
		velocity = new Vector3 (0, 0, 0);
		movement = new Vector3 (0, 0, 0);
	}
	
	void Update () {
		transform.Rotate (new Vector3 (0,Input.GetAxis("Mouse X") * Time.deltaTime * 100,0));

		velocity.y += mass * Physics.gravity.y * Time.deltaTime;
//		velocity -= velocity * drag * Time.deltaTime;

		if (character.isGrounded) {
			velocity.y = -0.01f;
			movement.z = Mathf.Lerp (movement.z, Input.GetAxis ("Vertical") * speed.y, Time.deltaTime * acceleration.y);
			movement.x = Mathf.Lerp (movement.x, Input.GetAxis ("Horizontal") * speed.x, Time.deltaTime * acceleration.x);
			if (Input.GetButtonDown ("Jump")) {
				velocity.y = jump;
			}
		} else {
			movement.z = Mathf.Lerp (movement.z, Input.GetAxis("Vertical") * speed.y, Time.deltaTime * airAcceleration.y);
			movement.x = Mathf.Lerp (movement.x, Input.GetAxis("Horizontal") * speed.x, Time.deltaTime * airAcceleration.x);
		}

		if (character.isGrounded && (Input.GetButton ("Vertical") || Input.GetButton ("Horizontal"))) {
			anim.SetBool ("walk", true);
		} else {
			anim.SetBool ("walk", false);
		}


		Vector3 finalMovement = ((transform.rotation * movement) * Time.deltaTime);
		Vector3 finalVelocity = velocity * Time.deltaTime;
	
		character.Move(finalVelocity + finalMovement);
	}
}
