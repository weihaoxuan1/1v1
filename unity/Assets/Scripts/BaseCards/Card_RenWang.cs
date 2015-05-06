using UnityEngine;
using System.Collections;

public class Card_RenWang : Card_Equipment {

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
		AllEventDelegate.Instance.RegOnBeingShaDelegate(EquipmentEffect);
	}

	protected override void OnUnequiped (Player user)
	{
		base.OnUnequiped (user);
		AllEventDelegate.Instance.UnregOnBeingShaDelegate(EquipmentEffect);
	}

	void OnClick()
	{
		if(clickable)
		{
			OnEquiped(Player_Man.Instance);
		}
	}

	bool EquipmentEffect(Player user, GameObject sha)
	{
		if(sha.GetComponent<Card_Sha>().color == 1 || sha.GetComponent<Card_Sha>().color == 3)
		{
			return false;
		}
		else 
			return true;
	}
}
