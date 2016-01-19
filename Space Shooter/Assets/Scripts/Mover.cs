/// <summary>
///控制子弹和陨石一生成就立刻向前走 
/// </summary>
using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	private Rigidbody r;

	void Start () 
	{
		r = GetComponent<Rigidbody> ();
		r.velocity = transform.forward * speed;
	}

}
