using UnityEngine;
using System.Collections;

public class Card_Tao : Card {

    public Card_Tao()
    {
        name = "tao";
    }
	// Use this for initialization
	void Start () {
        //name = "tao";
	}
	
	// Update is called once per frame
	void Update () {
		if(((MainProcess.Instance.isMyTurn && MainProcess.Instance.GetCurstage() == MainProcess.Stage.playing) || Player_Man.Instance.isCallingTao) && !Player_Man.Instance.IfFullHealth())
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
        user.IncreaseHp(1);
    }

	void OnClick()
	{
		if(clickable)
		{
			Effect(Player_Man.Instance);
		}
	}
}
