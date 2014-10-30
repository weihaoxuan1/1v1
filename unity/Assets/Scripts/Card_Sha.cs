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
        user.opposite.CallingShan();
        //user.opposite.DecreaseHp(1);
	}
}