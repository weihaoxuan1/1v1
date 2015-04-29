using UnityEngine;
using System.Collections;

public class OnCardPileClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        print("click deck");
        if(MainProcess.Instance.GetCurstage() != MainProcess.Stage.drawing)return;
        print("OnCardPileClicked");
        Player_Man.Instance.Draw(2);
        Player_Man.Instance.isDrawingStage = false;
        MainProcess.Instance.NextStage();
    }
}
