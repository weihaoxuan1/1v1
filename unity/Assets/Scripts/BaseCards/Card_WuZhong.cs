using UnityEngine;
using System.Collections;

public class Card_WuZhong : Card {

	public Card_WuZhong()
	{
		name = "wuzhong";
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
		user.Draw (2);

	}

	void OnClick()
	{
		if(clickable)
			Effect(Player_Man.Instance);
	}
}
