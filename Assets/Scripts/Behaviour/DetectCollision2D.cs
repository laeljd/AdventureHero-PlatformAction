using UnityEngine;
using System.Collections;

namespace AdventureHero.Behavours{
	//[RequireComponent(typeof(Collider2D))]
	public class DetectCollision2D : MonoBehaviour {

		protected void OnCollisionEnter2D(Collision2D collision){
			/// <summary>
			/// colisao com o espinho
			/// </summary>
			if (collision.collider.CompareTag("Saw")) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}