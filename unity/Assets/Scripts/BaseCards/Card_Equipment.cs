using UnityEngine;
using System.Collections;

public class Card_Equipment : Card {

	public bool equipmentType;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void OnEquiped(Player user)
	{
		if(!equipmentType) 
		{
			gameObject.transform.parent = user.wuQiArea.transform;
			gameObject.transform.localPosition = new Vector3();
			user.wuQi = gameObject;
		}
		else
		{
			gameObject.transform.parent = user.fangJuArea.transform;
			gameObject.transform.localPosition = new Vector3();
			user.fangJu = gameObject;
		}
	}

	protected virtual void OnUnequiped(Player user)
	{
		gameObject.transform.parent = GameObject.Find("TempPlace").transform;
		gameObject.transform.localPosition = new Vector3();
		if(!equipmentType)
		{
			user.wuQi = null;
		}
		else
		{
			user.fangJu = null;
		}
	}
}
