using UnityEngine;

public class PlayerGrounded : MonoBehaviour {

	public Transform groundCheck;

	public LayerMask whatIsGround;
	public float groundRadius = 0.1f;

	public bool isGrounded = false;
	
	private void Update() {
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}
}
