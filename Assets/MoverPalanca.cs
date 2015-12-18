using UnityEngine;
using System.Collections;

public class MoverPalanca : MonoBehaviour {

	public Transform bridgeAnimate;
	public bool activate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if(hit.collider.tag == "Palanca"){
				Debug.Log ("Encuentra palanca");
				hit.transform.GetComponent<Animator>().SetTrigger("ActivarPalanca");
			}
		}
			Debug.DrawLine(ray.origin, hit.point);*/
	
	}

	void OnTriggerEnter(Collider coll){
		
		if(coll.gameObject.tag == "Player"){
			//transform.GetComponent<Animator>().SetTrigger("ActivarPalanca");
		}
		

	}



	void OnSelect(string command){
		if(command == "Usar" && activate){
			transform.GetComponent<Animator>().SetTrigger("ActivarPalanca");
		}else if(command == "Activar" && !activate){
			StartCoroutine("EsperarTiempo", 0.5f);
		}
	}

	IEnumerator EsperarTiempo(float tiempo){
		yield return new WaitForSeconds(tiempo);
		Application.LoadLevel("PuzzleCadenas");
	}



	// Call in animation
	void ActivateBridge(){
		bridgeAnimate.GetComponent<Animator>().SetTrigger("Activate");
	}

}
