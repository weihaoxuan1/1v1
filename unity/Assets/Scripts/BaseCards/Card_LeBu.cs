using UnityEngine;
using System.Collections;

public class Card_LeBu : Card {

	Card_LeBu()
	{
		name = "lebu";
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(MainProcess.Instance.isMyTurn && MainProcess.Instance.GetCurstage() == MainProcess.Stage.playing && gameObject.transform.parent.gameObject.name == "PlayerHandCard")
		{
			clickable = true;
		}
		else 
		{
			clickable = false;
		}
	}

	public override void Effect(Player user)
	{
		//base.Effect(user);
		user.opposite.CallingWuXie();
		if(Deck.Instance.Judge().GetComponent<Card>().color != 2)
		{
			MainProcess.Instance.RegOnStageDelegate(JumpPlayingStage);
		}
	}
	
	void OnClick()
	{
		if(clickable)
		{
			gameObject.transform.parent = GameObject.Find ("EnemyJudgeCard").gameObject.transform;
			gameObject.transform.localPosition = new Vector3();
			gameObject.transform.Rotate (new Vector3(90,0,0));
			MainProcess.Instance.RegOnStageDelegate(OnJudgeStage);
		}
	}

	void OnJudgeStage(MainProcess.StageEvent stage)
	{
		if(stage.curStage == MainProcess.Stage.judgeing)
			Effect(Player_Man.Instance);
	}

	void JumpPlayingStage(MainProcess.StageEvent stage)
	{
		if(stage.curStage == MainProcess.Stage.playStart)
		{
			MainProcess.Instance.JumpStage ();
		}
	}
}
