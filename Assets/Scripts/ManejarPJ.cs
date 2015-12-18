using UnityEngine;
using System.Collections;

public class ManejarPJ : MonoBehaviour {


	public GameObject pjRagDoll;
	public GameObject rastroRoca;
	public float dampVelocidad = 0.1f;

	bool andandoPorMadera;
	GameObject mRastro;
	Animator animator;
	PlayerPositions playerState;
	bool isGrounded;
	bool isRun;
	bool dead;
	Vector3 directionAttack;


	void Start(){
		dead = false;
		andandoPorMadera = true;
		isGrounded = true;
		isRun = false;
		playerState = PlayerPositions.RIGHT;
	}

	void Awake(){
		animator = GetComponent<Animator> ();
		//animator.SetLayerWeight (1, 1f);
	}


	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");

		if (h > 0 && playerState != PlayerPositions.RIGHT) {
			Turn();
			playerState = PlayerPositions.RIGHT;
		}

		if (h < 0 && playerState != PlayerPositions.LEFT) {
			Turn();
			playerState = PlayerPositions.LEFT;
		}


		float hSl = h / 25;
		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			Jump();
		}

		if(isGrounded && Input.GetKeyDown(KeyCode.LeftShift)){
			isRun = true;
		}

		if(isGrounded && Input.GetKeyUp(KeyCode.LeftShift)){
			isRun = false;
		}

		if(isRun){
			transform.Translate (Vector3.right * hSl * 2, Space.World);
		}else{
			transform.Translate (Vector3.right * hSl, Space.World);
		}


		ManejarMovimiento(h, isGrounded, isRun);
	}

	void ManejarMovimiento(float movHorizontal, bool estaSaltando, bool isRun){
		animator.SetBool ("Salta", estaSaltando);

		// Si hay movimiento en el eje x
		if (movHorizontal != 0f) {
			// Cambiar rotacion y velocidad
			animator.SetFloat ("Velocidad", 1f, dampVelocidad, Time.deltaTime);
		} else {
			// Velocidad 0
			animator.SetFloat ("Velocidad", 0);
		}
	}

	void Turn(){
		transform.rotation *= Quaternion.AngleAxis (180, Vector3.up);
	}

	void Jump(){
		isGrounded = false;
		GetComponent<Rigidbody> ().AddForce (Vector3.up * 20, ForceMode.Impulse);
	}

	public enum PlayerPositions{
		LEFT, INTER, RIGHT
	};

	void OnTriggerEnter(Collider coll){

		if(coll.gameObject.tag == "Madera"){
			DejarRastroFuego();
			//coll.gameObject.GetComponent<Animator>().SetTrigger("Activate");
		}

		isGrounded = true;
	}


	void DejarRastroFuego(){
		if(andandoPorMadera){
			andandoPorMadera = false;
			mRastro = Instantiate(rastroRoca, transform.position, Quaternion.identity) as GameObject;
			mRastro.GetComponent<Rigidbody>().AddForce(600 * transform.forward);
			Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), mRastro.GetComponent<Collider>());
		}
	}


	void ApplyDamage(float damage) {
		if(damage >= 1 && !dead){
			Instantiate(pjRagDoll, transform.position, transform.rotation);
			Destroy(gameObject);
			dead = true;
		}
	}


	void AttackFire(Vector3 position){
		mRastro = Instantiate(rastroRoca, transform.position, Quaternion.identity) as GameObject;
		mRastro.GetComponent<Rigidbody>().AddForce(10 * position);
		//Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), mRastro.GetComponent<Collider>());
	}


	
	
}


