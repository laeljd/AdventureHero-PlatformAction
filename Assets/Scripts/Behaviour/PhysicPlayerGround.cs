using UnityEngine;
using System.Collections;

public class PhysicPlayerGround : MonoBehaviour {


	float maxSpeed = 10f;
	bool facingRight = true;
	Rigidbody2D rigidbody;
	Transform transform;
	float jumpForce = 15f;

	public bool grounded = false;
	public Transform groundedCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private bool doubleJump = false;

    public AudioClip sound;
    private AudioSource audio;

    void Start () {
		transform = gameObject.GetComponent<Transform>();
		rigidbody = gameObject.GetComponent<Rigidbody2D>();
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundedCheck.position, groundRadius, whatIsGround);

		if(grounded)
			doubleJump = false;

		float move = Input.GetAxis("Horizontal");

		rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

		if(move > 0 && !facingRight)
			flip();
		if(move < 0 && facingRight)
			flip();
			


	}

	void Update(){

		if((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space)){
			//rigidbody.AddForce(new Vector2(0, jumpForce));
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);//Better AddForce()
            audio.PlayOneShot(sound);
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y + jumpForce);// = AddForce()
            if (!grounded && !doubleJump)
				doubleJump = true;
		}
	}


	//GroundedCheck
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow ;
		Gizmos.DrawWireSphere (groundedCheck.position, groundRadius);
	}


	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
