using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent (typeof (GravityBody))]
public class FirstPerson : MonoBehaviour {

	public float mouseSensitivityX = 1;
	public float mouseSensitivityY = 1;
	public float walkSpeed = 6;
	public float jumpForce = 200;
	public LayerMask groundedMask;

	GravityAttractor planet;
	bool grounded;
	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	float verticalLookRotation;
	Rigidbody rb;
	Transform cameraTransform;
	private int jumpCount;
	Vector3 playerPos;
	Vector3 planetPos;
	Vector3 planetSize;

	public Image img;
	public float water = 1.0f;
	public ParticleSystem wgun1;
	public ParticleSystem wgun2;
	// Use this for initialization

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
		jumpCount = 0;
		playerPos = rb.transform.position;
		grounded = true;
		planet = GameObject.FindWithTag ("Planet").GetComponent<GravityAttractor> ();

		planetPos = planet.transform.position;
		planetSize = planet.transform.localScale;

		wgun1.Stop();
		wgun2.Stop();

		
	}


	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Input.GetAxisRaw("RSX") * mouseSensitivityX);
		verticalLookRotation -= Input.GetAxisRaw("RSY") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation,-60,60);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		Vector3 moveDir = new Vector3(inputX,0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);

		if ((playerPos.x <= (planetPos.x + planetSize.x/2 + 10)) && 
			(playerPos.y <= (planetPos.y + planetSize.y/2 + 10)) &&
			(playerPos.z <= (planetPos.z + planetSize.z/2 + 10))){
				grounded = true;
			}

		if (grounded) {
			jumpCount = 0;
		}

		img.rectTransform.localScale = new Vector3(water, 1f, 1f);
		if (Input.GetButton("AButton") && water > 0) {
			water -= 0.001f;
		}
		if (Input.GetButtonDown("AButton") && water > 0) {
			wgun1.Play ();
			wgun2.Play ();
		}			
		if (Input.GetButtonUp("AButton") && water > 0) {
			wgun1.Stop();
			wgun2.Stop();
		}			
	}

	void FixedUpdate() {
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + localMove);
		if ( (Input.GetKeyDown("space") || Input.GetButtonDown("XButton"))  && jumpCount < 3) {
			rb.AddForce (transform.up * jumpForce);
			jumpCount++;
			grounded = false;

		}

		if ((Input.GetKeyDown ("c") || Input.GetButtonDown("BButton")) && jumpCount < 3) {
			rb.AddForce (transform.forward * jumpForce);
			grounded = false;
			jumpCount++;

		}
	}
}
