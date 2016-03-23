using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
	public class CameraScript : BaseBehaviour {

		public float intensityShake;
		public float timerShake;
		private float fatorShake;

		private Vector3 originalPosition;

		public Transform target;
		public float margin;

		// Use this for initialization
		void Start () {
			target = GameObject.Find("Player").GetComponent<Transform>();
		}

		void OnGUI ()
		{
			if (GUI.Button(new Rect(10f, 100f, 80f, 30f), "Tremer tela")) GetComponent<CameraScript>().Shake();
		}
		
		// Update is called once per frame
		void Update () {
			var positionX = transform.position;

			if(positionX.x < target.position.x - margin ){
				positionX.x = target.position.x - margin;
			}
			if(positionX.x > target.position.x + margin ){
				positionX.x = target.position.x + margin;
			}

			transform.position = positionX;


			if(fatorShake > 0){
				fatorShake -= timerShake * Time.deltaTime;
				if(fatorShake > 0){
				transform.position = new Vector3(originalPosition.x + Random.Range (-fatorShake,fatorShake),
				                                 originalPosition.y + Random.Range (-fatorShake,fatorShake),transform.position.z);
				}else{
					transform.position = new Vector3(originalPosition.x, originalPosition.y, transform.position.z);
				}
			}else{
				fatorShake = 0;
			}


		}
		public void Shake(){
			originalPosition = transform.position;
			fatorShake = intensityShake;
		}

	}
}