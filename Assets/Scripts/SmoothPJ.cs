using UnityEngine;
using System.Collections;

public class SmoothPJ : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	Camera camara;


	void Start(){
		camara = GetComponent<Camera>();
	}


	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = camara.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camara.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}


		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}
	} 

}
