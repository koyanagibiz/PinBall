using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	private GameObject scoreText;

	private int score=0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		this.scoreText = GameObject.Find("ScoreText");

	}


	// Update is called once per frame
	void Update ()
	{
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log(other.gameObject.tag + " のタグを持つオブジェクトに衝突しました");

		if (other.gameObject.tag == "SmallStarTag")
		{
			score +=10;
		}
		else if (other.gameObject.tag == "LargeStarTag")
		{
			score +=150;
		}
		else if(other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
		{
			score +=300;
		}
		Debug.Log (score);
		this.scoreText.GetComponent<Text> ().text = "Score:"+score;
	}
}