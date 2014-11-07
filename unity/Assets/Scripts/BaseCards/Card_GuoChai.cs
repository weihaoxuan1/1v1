using UnityEngine;
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
	
	}

    public override void Effect(Player user)
    {
        base.Effect(user);
        user.isCallingAllChoose = true;
        //Deck.Instance.DiscardCard(user.opposite.LostCard(
    }

}
