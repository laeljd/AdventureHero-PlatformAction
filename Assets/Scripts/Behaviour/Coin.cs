using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
	//[RequireComponent(typeof(Collider2D))]
	public class Coin : MonoBehaviour {

		private new Rigidbody2D rigidbody;
		public float hitVerticalVelocity ;
		public AudioClip sound;
		private AudioSource audio;

		void Start(){
			this.rigidbody = this.GetComponentInParent<Rigidbody2D> ();
			audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
			var velocity = this.rigidbody.velocity;
			velocity.y = hitVerticalVelocity;
			this.rigidbody.velocity = velocity;
		}

		protected void OnTriggerEnter2D(Collider2D collider){
			/// <summary>
			/// colisao com o espinho
			/// </summary>
			if (collider.CompareTag("Player")) {
				audio.PlayOneShot(sound);
				Destroy(transform.parent.gameObject);
			}
		}
	}
}