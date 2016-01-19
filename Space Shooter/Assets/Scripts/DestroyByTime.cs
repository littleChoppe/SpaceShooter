/// <summary>
/// 等待一定生存时间后删除爆炸效果
/// </summary>
using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float lifeTime;

	void Start()
	{
		Destroy (gameObject, lifeTime);
	}
}
