/// <summary>
/// 任何在跑出视野之外的东西都被销毁
/// </summary>
using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}
}
