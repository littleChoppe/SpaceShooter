/// <summary>
/// 控制飞机在一定范围内移动并发射子弹
/// </summary>
using UnityEngine;
using System.Collections;

//自己写的不继承MonoBehaviour的类需要序列化，就是在类上写上下面的一句话
[System.Serializable]
public class Boundary
{
	public float minX, maxX, minZ, maxZ;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;		//旋转角度
	public float fireRate;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	private float nextFire;
	private Rigidbody r;
	private AudioSource audioSource;

	void Start()
	{
		r = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update()
	{
		if(Input.GetButton("Fire1") && Time.time > nextFire)
		{
			//在这个函数里所有的代码都在同一帧执行
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			nextFire = Time.time + fireRate;
			audioSource.Play();
		}
	}

	void FixedUpdate () {
		//控制飞机移动
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		r.velocity = movement * speed;

		//限定飞机可以飞的范围
		r.position = new Vector3
		(
			Mathf.Clamp(r.position.x, boundary.minX, boundary.maxX),
			0.0f,
			Mathf.Clamp(r.position.z, boundary.minZ, boundary.maxZ)
		);

		//飞机左右移动时倾斜一定的角度
		r.rotation = Quaternion.Euler (0.0f, 0.0f, r.velocity.x * -tilt);

	}
}
