using UnityEngine;
using System.Collections;

public class Card_Shan : Card {

    public Card_Shan()
    {
        name = "shan";
    }
	// Use this for initialization
	void Start () {
        //Debug.Log("come from Card_Shan");
        //name = "shan";
	}
	
	// Update is called once per frame
	void Update () {
	    if(Player_Man.Instance.isCallingShan)
			clickable = true;
		else
			clickable = false;
	}

    public override void Effect(Player user)
    {
        base.Effect(user);
        user.isCallingShan = false;
    }

	void OnClick()
	{
		if(clickable)
		{
			Effect(Player_Man.Instance);
		}
	}
}
