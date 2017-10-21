using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParent : MonoBehaviour {
    public List<GameObject> players;
    public GameObject playerObj;
    //Seperate this into different class perhaps (?)
    public enum GameState { WaitingDice, DiceRolled, MovingPlayer, None };

    private GameState gameState;
    // Use this for initialization
    void Start () {
        
        gameState = GameState.WaitingDice;
        //Debug.Log((players[0].GetComponent<Player>()).pname);

    }
	
	// Update is called once per frame
	void Update () {
        //put it in case maybe
        if (gameState == GameState.DiceRolled) {
            int diceValue = (gameObject.GetComponentInChildren<RollDiceButton>()).getDiceValue();
            Debug.Log("Dice Rolled = " + diceValue);
            gameState = GameState.MovingPlayer;
            players[0].GetComponent<Player>().Move(diceValue);
        }
	}

    public void CreatePlayers()
    {
        float x = 0, y = 1.5f, z = 6;
        players = new List<GameObject>();
        GameObject go = Instantiate(playerObj, new Vector3(x, y, z), Quaternion.identity);
        go.transform.parent = this.transform;
        go.GetComponent<Player>().tile = gameObject.GetComponentInChildren<BoardGenerate>().tileObj[0].GetComponent<Tile>();
        go.GetComponent<Player>().gp = this;
        players.Add(go);
    }

    public GameState getGameState()
    {
        return this.gameState;
    }

    public void setGameState(GameState gstate)
    {
        this.gameState = gstate;
    }
}
