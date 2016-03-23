using UnityEngine;
using System.Collections;



namespace AdventureHero.Behavours{

	public class Move : BaseBehaviour {
		//representa as direcoes da direcao
		
		[Tooltip("unidades por segundos")]
		public float walkVelocity = 4.0f;
		public float runVelocity = 8.0f;
		public float timerClickRun = 0.3f;
		private new Rigidbody2D rigidbody;

		private float timeRun;
		public bool run;
		public bool walk;
		
		
		void Start(){
				this.rigidbody = this.GetComponent<Rigidbody2D> ();
		}
		
		void Update(){
			if (Input.GetAxisRaw ("Horizontal") != 0) {
				if(!walk){
						timeRun = timerClickRun;
				}
				walk = true;

				gameObject.GetComponent<Attack>().direction = Mathf.Sign(Input.GetAxisRaw ("Horizontal"));
			}
			else{
				if(timeRun > 0){
					run = true;
				}else{
					run = false;
				}
				walk = false;
			}

			if(walk){
				var velocity = this.rigidbody.velocity;
				if(run){
					velocity.x = Input.GetAxis("Horizontal") * this.runVelocity;
				}
				else{
					velocity.x = Input.GetAxis("Horizontal") * this.walkVelocity;
				}
				this.rigidbody.velocity = velocity;
			}

			if(timeRun > 0){
				timeRun -= Time.deltaTime;
			}else{
				timeRun = 0;
			}
		}
	}
}