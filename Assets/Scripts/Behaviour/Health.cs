using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{

	public class Health : BaseBehaviour {

		public float life;
		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
			if(life <= 0){
				if(this.name == "Player"){
					Application.LoadLevel("Playground");
				}else{
					Destroy(this.gameObject);
				}
			}		
		}
	}
}