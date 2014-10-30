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
	
	}

    public override void Effect(Player user)
    {
        user.IncreaseHp(1);
    }
}
