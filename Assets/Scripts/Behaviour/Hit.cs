using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
	public class Hit : BaseBehaviour {

		// Use this for initialization
		public bool hit;
		private new Rigidbody2D rigidbody;
		public float direction;
		public float hitHorizontalVelocity ;
		public float hitVerticalVelocity ;
		public float timerHit;

		void Start () {
			this.rigidbody = this.GetComponent<Rigidbody2D> ();
		}
		
		// Update is called once per frame
		void Update () {
			if(hit){
				timerHit = 0.2f;
				var velocity = this.rigidbody.velocity;
				velocity.x = direction * hitHorizontalVelocity;
				velocity.y = hitVerticalVelocity;
				this.rigidbody.velocity = velocity;
				hit = false;
			}


			if(timerHit > 0){
				timerHit -= Time.deltaTime;
			}else{
				timerHit = 0;
			}
		}
	}
}