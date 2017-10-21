using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDiceButton : MonoBehaviour {

    private GameParent gp;
    private int diceroll = 0;
    public GameObject text;
	// Use this for initialization
	void Start () {

        gp = gameObject.GetComponentInParent<GameParent>();
        Random.InitState(System.Environment.TickCount);

        //Need to fix this into a texture perhaps(?)
        GameObject text = new GameObject();
        TextMesh t = text.AddComponent<TextMesh>();
        t.text = "Roll Dice";
        t.fontSize = 30;
        t.color = Color.red;
        t.transform.localEulerAngles += new Vector3(90, 0, 0);
        t.transform.localPosition += new Vector3(14, 1, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (gp.getGameState() == GameParent.GameState.WaitingDice)
        {
            
            Debug.Log("Clicked!");
            diceroll = Random.Range(1, 6 + 1);
            gp.setGameState(GameParent.GameState.DiceRolled);
            text.GetComponent<TextMesh>().text = diceroll.ToString();
        }
        else
        {
            Debug.Log("It's not time to roll dice!");
        } 
        
    }

    public int getDiceValue()
    {
        return diceroll;
    }
}
