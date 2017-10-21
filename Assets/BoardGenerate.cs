using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Need a way to seperate board layout functions (interfaces) e.g. spiral board

public class BoardGenerate : MonoBehaviour {

    public TileType[] tileTypes;

    private int[] tiles;

    public GameObject[] tileObj;

    private int boardSizeX = 8;
    private int boardSizeY = 8;
    private int boardSize;
    private int tileOffSet = 6;

    //Use this for initialization
    void Start()
    {
        boardSize = boardSizeX * boardSizeY;
        CreateBoardLayout();
        CreateBoardVisual();
        gameObject.GetComponentInParent<GameParent>().CreatePlayers();
    }

    void CreateBoardLayout()
    {
        tiles = new int[boardSize];
        tileObj = new GameObject[boardSize];
        for (int i = 0; i < boardSize; i++)
        {
            tiles[i] = 0;
        }
    }



    void CreateBoardVisual()
    {
        GameObject go, prev=null;
        int x = 0, z = 0, left = -1;
        
        for (int i = 0; i < boardSize; i++)
        {
            if (i % boardSizeX == 0)
            {
                z += tileOffSet;
                left *= -1;
            }
            else
            {
                x += left * tileOffSet;
            }
            TileType tt = tileTypes[tiles[i]];
            go = Instantiate(tt.tileVisualPrefab, new Vector3(x, 0, z), Quaternion.identity);
            go.name = "Tile #" + (i+1);
            go.transform.parent = this.transform;
            tileObj[i] = go;

            GameObject text = new GameObject();
            text.transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);
            text.transform.parent = go.transform;
            TextMesh t = text.AddComponent<TextMesh>();
            t.text = (i+1).ToString();
            t.fontSize = 10;
            t.color = Color.blue;
            t.transform.localEulerAngles += new Vector3(90, 0, 0);
            t.transform.localPosition = text.transform.position + new Vector3(0, 0.5f, 0);

            if (prev != null) (prev.GetComponent<Tile>()).SetNextTile(go.GetComponent<Tile>());
            prev = go;
        }
    }



}
