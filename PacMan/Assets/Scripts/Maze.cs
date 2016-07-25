﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class Maze : MonoBehaviour {
    public int[,] maze = { {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                           {2,4,4,4,4,4,4,4,4,4,4,4,4,2,2,4,4,4,4,4,4,4,4,4,4,4,4,2,},
                           {2,4,2,2,2,2,4,2,2,2,2,2,4,2,2,4,2,2,2,2,2,4,2,2,2,2,4,2,},
                           {2,3,2,2,2,2,4,2,2,2,2,2,4,2,2,4,2,2,2,2,2,4,2,2,2,2,3,2,},
                           {2,4,2,2,2,2,4,2,2,2,2,2,4,2,2,4,2,2,2,2,2,4,2,2,2,2,4,2,},
                           {2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,2,},
                           {2,4,2,2,2,2,4,2,2,4,2,2,2,2,2,2,2,2,4,2,2,4,2,2,2,2,4,2,},
                           {2,4,2,2,2,2,4,2,2,4,2,2,2,2,2,2,2,2,4,2,2,4,2,2,2,2,4,2,},
                           {2,4,4,4,4,4,4,2,2,4,4,4,4,2,2,4,4,4,4,2,2,4,4,4,4,4,4,2,},
                           {2,2,2,2,2,2,4,2,2,2,2,2,0,2,2,0,2,2,2,2,2,4,2,2,2,2,2,2,},
                           {0,0,0,0,0,2,4,2,2,2,2,2,0,2,2,0,2,2,2,2,2,4,2,0,0,0,0,0,},
                           {0,0,0,0,0,2,4,2,2,0,0,0,0,0,0,0,0,0,0,2,2,4,2,0,0,0,0,0,},
                           {0,0,0,0,0,2,4,2,2,0,2,2,2,0,0,2,2,2,0,2,2,4,2,0,0,0,0,0,},
                           {2,2,2,2,2,2,4,2,2,0,2,0,0,0,0,0,0,2,0,2,2,4,2,2,2,2,2,2,},
                           {0,0,0,0,0,0,4,0,0,0,2,0,0,0,0,0,0,2,0,0,0,4,0,0,0,0,0,0,},
                           {2,2,2,2,2,2,4,2,2,0,2,0,0,0,0,0,0,2,0,2,2,4,2,2,2,2,2,2,},
                           {0,0,0,0,0,2,4,2,2,0,2,2,2,2,2,2,2,2,0,2,2,4,2,0,0,0,0,0,},
                           {0,0,0,0,0,2,4,2,2,0,0,0,0,0,0,0,0,0,0,2,2,4,2,0,0,0,0,0,},
                           {0,0,0,0,0,2,4,2,2,0,2,2,2,2,2,2,2,2,0,2,2,4,2,0,0,0,0,0,},
                           {2,2,2,2,2,2,4,2,2,0,2,2,2,2,2,2,2,2,0,2,2,4,2,2,2,2,2,2,},
                           {2,4,4,4,4,4,4,4,4,4,4,4,4,2,2,4,4,4,4,4,4,4,4,4,4,4,4,2,},
                           {2,4,2,2,2,2,4,2,2,2,2,2,4,2,2,4,2,2,2,2,2,4,2,2,2,2,4,2,},
                           {2,4,2,2,2,2,4,2,2,2,2,2,4,2,2,4,2,2,2,2,2,4,2,2,2,2,4,2,},
                           {2,3,4,4,2,2,4,4,4,4,4,4,4,0,0,4,4,4,4,4,4,4,2,2,4,4,3,2,},
                           {2,2,2,4,2,2,4,2,2,4,2,2,2,2,2,2,2,2,4,2,2,4,2,2,4,2,2,2,},
                           {2,2,2,4,2,2,4,2,2,4,2,2,2,2,2,2,2,2,4,2,2,4,2,2,4,2,2,2,},
                           {2,4,4,4,4,4,4,2,2,4,4,4,4,2,2,4,4,4,4,2,2,4,4,4,4,4,4,2,},
                           {2,4,2,2,2,2,2,2,2,2,2,2,4,2,2,4,2,2,2,2,2,2,2,2,2,2,4,2,},
                           {2,4,2,2,2,2,2,2,2,2,2,2,4,2,2,4,2,2,2,2,2,2,2,2,2,2,4,2,},
                           {2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,2,},
                           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}};

    public int MapWidth, MapHeight;
    public Vector2 MapOffset;

    public GameObject Wall, smallDot, bigDot;
    GameObject tempObj;
    // Use this for initialization
	void Start () {        
	    
	}

    public void CreateMaze()
    {
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                if (maze[i, j] == 2)
                {
                    tempObj = Instantiate(Wall, new Vector3(j + MapOffset.x, MapOffset.y - i, 0), Quaternion.identity) as GameObject;
                    tempObj.transform.parent = transform;
                }
                else if (maze[i, j] == 4)
                {
                    tempObj = Instantiate(smallDot, new Vector3(j + MapOffset.x, MapOffset.y - i, 0), Quaternion.identity) as GameObject;
                    tempObj.transform.parent = transform;
                }
                else if (maze[i, j] == 3)
                {
                    tempObj = Instantiate(bigDot, new Vector3(j + MapOffset.x, MapOffset.y - i, 0), Quaternion.identity) as GameObject;
                    tempObj.transform.parent = transform;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

[CustomEditor(typeof(Maze))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Maze myScript = (Maze)target;
        if (GUILayout.Button("Create Maze"))
        {
            myScript.CreateMaze();
        }
    }
}