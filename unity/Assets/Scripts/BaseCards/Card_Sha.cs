using UnityEngine;
using System.Collections;

public class Card_Sha : Card{
    public Card_Sha()
    {
        name = "sha";
    }

    void Start()
    {
        //name = "sha";
    }

	public override void Effect(Player user)
	{
        base.Effect(user);
        user.opposite.CallingShan();
        //user.opposite.DecreaseHp(1);
	}
	
	public void OnClick()
	{
		Debug.Log ("click");
	}
}