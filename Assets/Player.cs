using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public string pname;

    public Tile tile;

    public GameParent gp;

    private bool moveState;
    private int steps; 
	// Use this for initialization
	void Start () {
        moveState = false;
        steps = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveState)
        {
            MovingToTile();
        }
	}

    public void Move(int n)
    {
        steps = n;
        moveState = true;
    }

    private void MovingToTile()
    {
        if (steps > 0)
        {
            Vector3 nexttilePos = tile.GetNextTile().GetPosition() + new Vector3(0,2.5f,0);
            if (Vector3.Distance(transform.position, nexttilePos) < 0.1f)
            {
                transform.position = nexttilePos;
                steps--;
                tile = tile.GetNextTile();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, nexttilePos, 6f * Time.deltaTime);
            }
            
        }
        else
        {
            moveState = false;
            gp.setGameState(GameParent.GameState.WaitingDice);
        }
    }
}
