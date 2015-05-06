using UnityEngine;
using System.Collections;

public class Card_WuXie : Card {

	Card_WuXie()
	{
		name = "wuxie";
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Player_Man.Instance.isCallingWuXie)
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
		user.isCallingWuXie = false;

		
	}
	
	void OnClick()
	{
		if(clickable)
			Effect(Player_Man.Instance);
	}
}
