using UnityEngine;
using System.Collections;

public class AllEventDelegate : MonoBehaviour {
	public static AllEventDelegate Instance ;
	AllEventDelegate(){
		Instance = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public delegate bool OnPlayedShaDelegate(Player user,GameObject sha);
	private OnPlayedShaDelegate onPlayerShaDels;
	public void RegOnPlayedShaDelegate(OnPlayedShaDelegate onPlayedShaDel) {onPlayerShaDels += onPlayedShaDel;}
	public void UnregOnPlayedShaDelegate(OnPlayedShaDelegate onPlayedShaDel) {if(onPlayerShaDels != null) onPlayerShaDels -= onPlayedShaDel;}
	
	public delegate bool OnCallingShanDelegate(Player user,GameObject card);
	private OnCallingShanDelegate onCallingShanDels;
	public void RegOnCallingShanDelegate(OnCallingShanDelegate onCallingShanDel) {onCallingShanDels += onCallingShanDel;}
	public void UnregOnCallingShanDelegate(OnCallingShanDelegate onCallingShanDel) {if(onCallingShanDels != null) onCallingShanDels -= onCallingShanDel;}

	public delegate bool OnBeingShaDelegate(Player user,GameObject sha);
	private OnBeingShaDelegate onBeingShaDels;
	public void RegOnBeingShaDelegate(OnBeingShaDelegate onBeingShaDel) {onBeingShaDels += onBeingShaDel;}
	public void UnregOnBeingShaDelegate(OnBeingShaDelegate onBeingShaDel) {if(onBeingShaDels != null) onBeingShaDels -= onBeingShaDel;}

	public delegate bool OnPlayedShanDelegate(Player user,GameObject sha);
	private OnPlayedShanDelegate onPlayerShanDels;
	public void RegOnPlayedShanDelegate(OnPlayedShanDelegate onPlayedShanDel) {onPlayerShanDels += onPlayedShanDel;}
	public void UnregOnPlayedShanDelegate(OnPlayedShanDelegate onPlayedShanDel) {if(onPlayerShanDels != null) onPlayerShanDels -= onPlayedShanDel;}

	public delegate bool OnAlmostDamageDelegate(Player user,GameObject card);
	private OnAlmostDamageDelegate OnAlmostDamageDels;
	public void RegOnAlmostDamageDelegate(OnAlmostDamageDelegate OnAlmostDamageDel) {OnAlmostDamageDels += OnAlmostDamageDel;}
	public void UnregOnAlmostDamageDelegate(OnAlmostDamageDelegate OnAlmostDamageDel) {if(OnAlmostDamageDels != null) OnAlmostDamageDels -= OnAlmostDamageDel;}

}
