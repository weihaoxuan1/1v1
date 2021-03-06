﻿using UnityEngine;
using System.Collections;

public class Card_GuoChai : Card {

    public Card_GuoChai()
    {
        name = "guochai";
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
        user.isCallingAllChoose = true;
		Player_Enemy.Instance.RegOnChooseCardDelegate(GetCard);
        //Deck.Instance.DiscardCard(user.opposite.LostCard(
    }
	public void GetCard(GameObject card)
	{

		//Player_Man.Instance.GetCard (card);
		Player_Enemy.Instance.LostCard (card);
	}
	
	void OnClick()
	{
		if(clickable)
			Effect(Player_Man.Instance);
	}
}
