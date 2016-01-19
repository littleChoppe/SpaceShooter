/// <summary>
///陨石碰到子弹后销毁自己和子弹 
/// </summary>
using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;


	void Start()
	{
		//找到拥有GameController标志的物体
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject)
			//找到物体上的脚本
			gameController = gameControllerObject.GetComponent<GameController> ();

		if (gameController == null)
			Debug.Log ("Cannot find 'GameController' script");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
			return;

		Instantiate (explosion, transform.position, transform.rotation);
		gameController.AddScore (scoreValue);
		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		//Destroy()这个函数在执行时只是把物体标志成要销毁，在执行完函数的下一秒再统一销毁被标志的物体，所以语句无前后之分
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
