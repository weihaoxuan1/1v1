using UnityEngine;
using System.Collections;

public class Card_WanJian : Card {

	Card_WanJian()
	{
		name = "wanjian";
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
		if(!user.opposite.CallingWuXie())
			user.opposite.CallingShan();

	}

	void OnClick()
	{
		if(clickable)
			Effect(Player_Man.Instance);
	}
}
