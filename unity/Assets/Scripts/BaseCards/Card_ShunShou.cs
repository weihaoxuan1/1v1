﻿using UnityEngine;
using System.Collections;

public class Card_ShunShou : Card {

    //Player u = null;

    public Card_ShunShou()
    {
        name = "shunshou";
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
        //u = user;
    }

    public void GetCard(GameObject card)
    {
        //使用者增加(对方失去手牌(返回此卡在对方手牌的索引)),操作估计有点多余,以后可以看看怎么改
        //u.holdCards.Add(u.opposite.LostCard(u.opposite.holdCards.IndexOf(this)));
		Player_Man.Instance.GetCard (Player_Enemy.Instance.LostCard (card));

    }

	void OnClick()
	{
		if(clickable)
			Effect(Player_Man.Instance);
	}
}
