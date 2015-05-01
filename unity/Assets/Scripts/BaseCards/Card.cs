using UnityEngine;
using System.Collections;
/// <summary>
/// ¿¨Æ¬»ùÀà
/// </summary>
public class Card : MonoBehaviour{

	public int color;
	public int number;
	public bool clickable;
	public string name;

	public virtual void Effect(Player user)
    {
        Deck.Instance.DiscardCard(this);
		user.holdCards.Remove (this.gameObject);
		Destroy(this.gameObject);
    }

    public void OnChooseCard()
    {
        Player_Enemy.Instance.OnChose(this);
    }
}