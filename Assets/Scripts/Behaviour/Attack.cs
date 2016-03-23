using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{

	public class Attack : BaseBehaviour {

		private bool attack;
		private RaycastHit2D hit;
		public LayerMask layerMask;
		private float size = 1;
		public float direction;

		// Use this for initialization
		void Start () {
		}
		
		// Update is called once per frame
		void Update () {
            direction = 
            hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), size, layerMask);
			if(hit){
				if(hit.collider.gameObject.CompareTag("Enemy")){
					attack = (Input.GetButtonDown("Fire1"));
					if(attack){
						hit.collider.gameObject.GetComponent<Hit>().direction = direction;
						hit.collider.gameObject.GetComponent<Hit>().hit = attack;
					}
				}
				else{
					attack = false;
				}
			}
			Debug.DrawLine(transform.position, new Vector3(transform.position.x + (direction * size) ,transform.position.y,0), Color.red);
		}
	}
}