using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
public class Jump : BaseBehaviour {

	public float jumpVelocity = 800.0f;
	public AudioClip sound;
	private AudioSource audio;
	//tags
	private string groundTag = "Ground";
	//bandeiras
	private new Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = this.GetComponent<Rigidbody2D> ();
		audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}
	
	private void OnCollisionStay2D(Collision2D collision) {
		/// <summary>
		/// colisao com o chao
		/// </summary>
		if (collision.collider.CompareTag (this.groundTag)) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				audio.PlayOneShot(sound);
				var velocity = this.rigidbody.velocity;
				
				velocity.y = this.jumpVelocity;
				
				this.rigidbody.velocity = velocity;
			}
		}
	}
}
}