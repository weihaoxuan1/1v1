using UnityEngine;
using System.Collections;

public class Card_BaGua : Card_Equipment {

	public bool ifIgnoreFangJu;
	// Use this for initialization
	void Start () {
		equipmentType = true;
		ifIgnoreFangJu = false;
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

	protected override void OnEquiped (Player user)
	{
		base.OnEquiped (user);
		AllEventDelegate.Instance.RegOnCallingShanDelegate(EquipmentEffect);
	}

	protected override void OnUnequiped (Player user)
	{
		base.OnUnequiped (user);
		AllEventDelegate.Instance.UnregOnCallingShanDelegate(EquipmentEffect);
	}

	void OnClick()
	{
		if(clickable)
		{
			OnEquiped(Player_Man.Instance);
		}
	}

	bool EquipmentEffect(Player user,GameObject card)
	{
		if(ifIgnoreFangJu) return true;
		Card temp = Deck.Instance.Judge ();
		if(temp.color == 2 || temp.color == 4)
		{
			user.isCallingShan = false;
			return false;
		}
		else
			return true;
	}
}
