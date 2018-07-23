using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

	static int cWidth = 16;
	static int cHeight = 32;
	static int cDepth = 16;
	public static Vector3[,,] allVertices = new Vector3[cWidth+1,cHeight+1,cDepth+1];
	public static Vector3[] allNormals = new Vector3[6];
	public enum NDIR {UP, DOWN, LEFT, RIGHT, FRONT, BACK}
	public GameObject chunkPrefab;

	// Use this for initialization
	void Start () {
		//generate all vertices
		for(int z = 0; z <= cDepth; z++)
			for(int y = 0; y <= cHeight; y++)
				for(int x = 0; x <= cWidth; x++)
				{
					allVertices[x,y,z] = new Vector3(x,y,z);	 
				}

		allNormals[(int) NDIR.UP] = Vector3.up;
		allNormals[(int) NDIR.DOWN] = Vector3.down;
		allNormals[(int) NDIR.LEFT] = Vector3.left;
		allNormals[(int) NDIR.RIGHT] = Vector3.right;
		allNormals[(int) NDIR.FRONT] = Vector3.forward;
		allNormals[(int) NDIR.BACK] = Vector3.back;

		//build chunk here
		GameObject c = Instantiate(chunkPrefab,this.transform.position,this.transform.rotation);
		c.GetComponent<Chunk>().CreateChunk(cWidth, cHeight, cDepth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
