using UnityEngine;
using System.Collections;

public class Card_BingLiang : Card {

	Card_BingLiang()
	{
		name = "bingliang";
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
		if(Deck.Instance.Judge().color != 3)
		{
			MainProcess.Instance.RegOnStageDelegate(JumpDrawingStage);
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
	
	void JumpDrawingStage(MainProcess.StageEvent stage)
	{
		if(stage.curStage == MainProcess.Stage.drawing)
		{
			MainProcess.Instance.JumpStage ();
		}
	}
}
