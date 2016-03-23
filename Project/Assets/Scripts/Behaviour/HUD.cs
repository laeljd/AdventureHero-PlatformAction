using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
	public class HUD : MonoBehaviour {

		private Health healt;
		public Vector2 position;
		public Vector2 size;
		public Texture unityLife;


		// Use this for initialization
		void Start () {
			healt = GameObject.Find("Player").GetComponent<Health>();
			position = new Vector2(0,0);
			size = new Vector2(10,50);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnGUI() {
			if(healt.life > 0){
				var posIniX = position;
				for(int i = 0; i < healt.life; i++){
					posIniX.x = size.x * i;
					GUI.DrawTexture( new Rect(posIniX,size),unityLife);
				}
			}
		}
	}
}