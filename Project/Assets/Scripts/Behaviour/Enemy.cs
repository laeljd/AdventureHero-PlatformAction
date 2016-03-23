using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
	//[RequireComponent(typeof(Collider2D))]
	public class Enemy : MonoBehaviour {

		private Transform target;
		private new Rigidbody2D rigidbody;
		public float verticalVvelocity = 5f;
		private float direction;
		private Hit hit;
		public GameObject coin;
		private bool dropCoin;
		private new CameraScript camera;
		public float distanceFollowTarget;
		public AudioClip[] sound;
		private AudioSource audio;


		protected void OnCollisionEnter2D(Collision2D collision){
			/// <summary>
			/// colisao com o espinho
			/// </summary>
			if (collision.collider.CompareTag("Player")) {
				audio.PlayOneShot(sound[1]);
				collision.gameObject.GetComponent<Hit>().direction = direction;
				collision.gameObject.GetComponent<Hit>().hit = true;
				collision.gameObject.GetComponent<Health>().life -=1 ;
				camera.Shake();
			}
		}
		void Start(){
			this.rigidbody = this.GetComponent<Rigidbody2D> ();
			target = GameObject.Find("Player").GetComponent<Transform>();
			hit  = this.GetComponent<Hit>();
			camera = GameObject.Find("Main Camera").GetComponent<CameraScript>();
			audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		}
		void Update(){

			if(Mathf.Abs(transform.position.x - target.position.x) < distanceFollowTarget){
				
			
			if(transform.position.x > target.position.x){
				direction = -1;
			}else{
				direction = 1;
				}
			}else{
				direction = 0;
			}


			if(hit.timerHit <= 0){
				var velocity = this.rigidbody.velocity;
				velocity.x = direction * verticalVvelocity;
				this.rigidbody.velocity = velocity;
				dropCoin = true;
			}else{
				if(dropCoin){
					audio.PlayOneShot(sound[0]);
					Instantiate(coin, transform.position, Quaternion.identity);
					dropCoin = false;
					gameObject.GetComponent<Health>().life -=1 ;
					camera.Shake();
				}
			}
		}
	}
}