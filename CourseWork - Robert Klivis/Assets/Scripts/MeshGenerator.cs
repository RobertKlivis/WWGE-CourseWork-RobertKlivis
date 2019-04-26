using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]

public class MeshGenerator : MonoBehaviour {

    Mesh mesh;
    MeshCollider meshCollider;

    List<Vector3> vertexList;
    List<int> triIndexList;

    List<Vector2> UVList;

    int numQuads = 0;

	// Use this for initialization
	void Start () {

        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();

        vertexList = new List<Vector3>();
        triIndexList = new List<int>();

        UVList = new List<Vector2>();


        CreateQuad(1, 1, 1, new Vector2(0, 0.5f));
        CreateQuad(2, 1, 1, new Vector2(0.5f, 0.5f));
        CreateQuad(3, 1, 1, new Vector2 (0.5f, 0.5f));
        CreateQuad(-1, 0, 0, new Vector2(0.5f, 0.5f));

        mesh.RecalculateNormals();

        mesh.vertices = vertexList.ToArray();
        mesh.triangles = triIndexList.ToArray();

        mesh.uv = UVList.ToArray();

        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = mesh;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateQuad(int x, int y, int z, Vector2 uvCoords)
    {

        vertexList.Add(new Vector3(x, y + 1, 0));
        vertexList.Add(new Vector3(x + 1, y + 1, 0));
        vertexList.Add(new Vector3(x + 1, y, 0));
        vertexList.Add(new Vector3(x, y, 0));

        /*vertexList.Add(new Vector3(x + 1, y + 1, 0));
        vertexList.Add(new Vector3(x + 2, y + 1, 0));
        vertexList.Add(new Vector3(x + 2, y, 0));
        vertexList.Add(new Vector3(x + 1, y, 0));*/

        triIndexList.Add(numQuads * 4);
        triIndexList.Add((numQuads * 4) + 1);
        triIndexList.Add((numQuads * 4) + 3);
        triIndexList.Add((numQuads * 4) + 1);
        triIndexList.Add((numQuads * 4) + 2);
        triIndexList.Add((numQuads * 4) + 3);

        /*triIndexList.Add(numQuads * 4);
        triIndexList.Add((numQuads * 4) + 1);
        triIndexList.Add((numQuads * 4) + 3);
        triIndexList.Add((numQuads * 4) + 1);
        triIndexList.Add((numQuads * 4) + 2);
        triIndexList.Add((numQuads * 4) + 3);*/


        numQuads++;

        UVList.Add(new Vector2(uvCoords.x, uvCoords.y + 0.5f));
        UVList.Add(new Vector2(uvCoords.x + 0.5f, uvCoords.y + 0.5f));
        UVList.Add(new Vector2(uvCoords.x + 0.5f, uvCoords.y));
        UVList.Add(new Vector2(uvCoords.x, uvCoords.y));

    }
}
