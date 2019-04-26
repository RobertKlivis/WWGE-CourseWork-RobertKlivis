using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelChunk : MonoBehaviour {

    VoxelGenerator voxelGenerator;

    public int[,,] terrainArray;
    int chunkSize = 16;

    public delegate void EventBlockChanged();

    public static event EventBlockChanged OnEventBlockDestroyed;
    public static event EventBlockChanged OnEventBlockPlaced1;
    public static event EventBlockChanged OnEventBlockPlaced2;
    public static event EventBlockChanged OnEventBlockPlaced3;
    public static event EventBlockChanged OnEventBlockPlaced4;

    public string tex;

    // Use this for initialization
   void Start () {

        voxelGenerator = GetComponent<VoxelGenerator>();
        terrainArray = new int[chunkSize, chunkSize, chunkSize];

        voxelGenerator.Initialise();

        InitialiseTerrain();

        terrainArray = XMLVoxelFileWriter.LoadChunkFromXMLFile(16, "AssessmentChunk1");

        CreateTerrain();
        voxelGenerator.UpdateMesh();

    }
	
	// Update is called once per frame
	void Update () {

        
		
	}

    public void InitialiseChunk (string filename)
    {
        voxelGenerator = GetComponent<VoxelGenerator>();
        terrainArray = new int[chunkSize, chunkSize, chunkSize];

        voxelGenerator.Initialise();

        InitialiseTerrain();
        CreateTerrain();
        voxelGenerator.UpdateMesh();
    }

    void InitialiseTerrain()
    {
        for (int x = 0; x < terrainArray.GetLength(0); x++)
        {
            for (int y = 0; y < terrainArray.GetLength(1); y++)
            {
                for (int z = 0; z < terrainArray.GetLength(2); z++)
                {
                    if (y == 3)
                    {
                        terrainArray[x, y, z] = 1;

                    }
                    else if (y < 3)
                    {
                        terrainArray[x, y, z] = 2;
                    }
                }
            }
        }

    }

    public void CreateTerrain()
    {
        for (int x = 0; x < terrainArray.GetLength(0); x++)
        {
            for (int y = 0; y < terrainArray.GetLength(1); y++)
            {
                for (int z = 0; z < terrainArray.GetLength(2); z++)
                {
                    if (terrainArray[x, y, z] != 0)
                    {
                        
                        switch (terrainArray[x, y, z])
                        {
                            case 1:
                                tex = "Grass";
                                break;
                            case 2:
                                tex = "Dirt";
                                break;
                            case 3:
                                tex = "Sand";
                                break;
                            case 4:
                                tex = "Stone";
                                break;
                            default:
                                tex = "Grass";
                                break;
                        }
                        if (x == 0 || terrainArray[x - 1, y, z] == 0)
                        {
                            voxelGenerator.CreateNegativeXFace(x, y, z, tex);
                        }

                        if (x == terrainArray.GetLength(0) - 1 || terrainArray[x + 1, y, z] == 0)
                        {
                            voxelGenerator.CreatePositiveXFace(x, y, z, tex);
                        }

                        if (y == 0 || terrainArray[x, y - 1, z] == 0)
                        {
                            voxelGenerator.CreateNegativeYFace(x, y, z, tex);
                        }

                        if (y == terrainArray.GetLength(1) - 1 || terrainArray[x, y + 1, z] == 0)
                        {
                            voxelGenerator.CreatePositiveYFace(x, y, z, tex);
                        }

                        if (z == 0 || terrainArray[x, y, z - 1] == 0)
                        {
                            voxelGenerator.CreateNegativeZFace(x, y, z, tex);
                        }

                        if (z == terrainArray.GetLength(2) - 1 || terrainArray[x, y, z + 1] == 0)
                        {
                            voxelGenerator.CreatePositiveZFace(x, y, z, tex);
                        }

                    }

                }
            }
        }
    }

    public void SetBlock(Vector3 index, int blockType)
    {
        if ((index.x > 0 && index.x < terrainArray.GetLength(0)) && (index.y > 0 && index.y < terrainArray.GetLength(1)) && (index.z > 0 && index.z < terrainArray.GetLength(2)))
        {
            terrainArray[(int)index.x, (int)index.y, (int)index.z] = blockType;
            CreateTerrain();
            GetComponent<VoxelGenerator>().UpdateMesh();

            if (blockType == 0)
            {
                OnEventBlockDestroyed();
            }

            if (blockType == 1)
            {
                OnEventBlockPlaced1();
            }

            if (blockType == 2)
            {
                OnEventBlockPlaced2();
            }

            if (blockType == 3)
            {
                OnEventBlockPlaced3();
            }

            if (blockType == 4)
            {
                OnEventBlockPlaced4();
            }
        }
    }

}
