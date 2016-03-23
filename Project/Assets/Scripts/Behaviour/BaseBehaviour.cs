using UnityEngine;
using System.Collections;


//name space. nome do projeto, nome da pasta 
namespace AdventureHero.Behavours{

	public class BaseBehaviour : MonoBehaviour {

		// o new serve para sobreescrever as coisas do pai, precisa ja que o nome da variavei ja existe no monobehavor
		public new Transform transform;

		//o virtual e para dizer que isso pode ser sebreescrito pois os filhos irao usar diferentes Awake
		protected virtual void Awake() {
			this.transform = this.GetComponent<Transform> ();
		}
	}
}