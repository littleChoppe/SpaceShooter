/// <summary>
/// 设置陨石自动自转
/// </summary>
using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	private Rigidbody r;

	void Start()
	{
		r = GetComponent<Rigidbody> ();
		//设置自转速度
		r.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
