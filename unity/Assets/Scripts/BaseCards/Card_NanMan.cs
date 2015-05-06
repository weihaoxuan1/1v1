using UnityEngine;
using System.Collections;

public class Card_NanMan : Card {

	Card_NanMan()
	{
		name = "nanman";
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
		base.Effect(user);
		user.opposite.CallingWuXie();
		user.opposite.CallingSha();

	}

	void OnClick()
	{
		if(clickable)
			Effect(Player_Man.Instance);
	}
}
