using UnityEngine;
using System.Collections;
/// <summary>
/// ¿¨Æ¬»ùÀà
/// </summary>
public class Card : MonoBehaviour{

	public int color;
	public int number;
	public bool clickable;
	public bool clickableAllChoose;
	public string name;

	public virtual void Update()
	{
		if(Player_Man.Instance.isCallingAllChoose && gameObject.transform.parent.gameObject.name == "EnemyHandCard")
		{
			clickableAllChoose = true;
		}
		else 
		{
			clickableAllChoose = false;
		}
	}

	public virtual void Effect(Player user)
    {
        Deck.Instance.DiscardCard(gameObject);
		user.holdCards.Remove (this.gameObject);
		GameObject playCardPile = GameObject.Find("PlayCardPile")as GameObject;
		gameObject.transform.parent = playCardPile.transform;
		gameObject.transform.localPosition = new Vector3();
		print ("Played "+gameObject.name+" and send it to PlayCardPile)");
		//Destroy(this.gameObject);
    }

    public void OnChooseCard()
    {
        Player_Enemy.Instance.OnChoose(this.gameObject);
    }

	protected void BaseOnClick()
	{
		print ("Base Card OnClick");
		if(clickableAllChoose)
		{

			Player_Enemy.Instance.OnChoose(this.gameObject);
		}
	}
}