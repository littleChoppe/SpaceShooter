/// <summary>
///控制陨石一波一波地自动生成直至飞机被撞毁和计算分数
/// </summary>
using UnityEngine;
//使用图形界面
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	//障碍物
	public GameObject hazard;
	//出生点
	public Vector3 spawnValue;
	//计算分数
	public Text scoreText;
	public Text gameOverText;
	public Text replayText;

	private int score;
	private bool replay;
	private bool gameOver;

	void Start ()
	{
		gameOverText.text = "";
		replayText.text = "";
		replay = false;
		gameOver = false;
		score = 0;
		UpdateScore ();
		//调用协同程序
		StartCoroutine (SpawnWaves());

	}

	void Update()
	{
		if (replay) 
		{
			if (Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves()
	{
		//等待一段时间后才开始
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				//一个一个地随机生成，每次循环等待一段时间再执行下一循环
				yield return new WaitForSeconds (spawnWait);
			}
			//一波一波生成，直至飞机被撞毁
			yield return new WaitForSeconds(waveWait);
			//游戏结束时结束while循环
			if (gameOver)
			{
				replayText.text = "Press 'R' to replay";
				replay = true;
			}
		}
	}

	public void AddScore(int scoreValue)
	{
		score += scoreValue;
		UpdateScore ();
	}

 	void UpdateScore( )
	{
		scoreText.text = "Score:" + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over !";
		gameOver = true;
	}
}
