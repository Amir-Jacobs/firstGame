using UnityEngine;

public class PlayerGrounded : MonoBehaviour {

	public Transform groundCheck;

	public LayerMask whatIsGround;
	public float groundRadius = 0.1f;

	public bool isGrounded = false;

	private float time;

	private void Update() {
		if (!Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround) &&
			time + .5f < Time.time)
			isGrounded = false;

		else if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
			isGrounded = true;
	}
}
