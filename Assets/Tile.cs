using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Tile nextTile;
    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public Tile GetNextTile()
    {
        return nextTile;
    }

    public void SetNextTile(Tile t)
    {
        nextTile = t;
    }
}
