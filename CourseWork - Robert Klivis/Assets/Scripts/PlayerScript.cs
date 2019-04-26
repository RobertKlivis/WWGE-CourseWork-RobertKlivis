using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public VoxelChunk voxelChunk;

    private bool Block1;
    private bool Block2;
    private bool Block3;
    private bool Block4;

    public int GrassBlocks;
    public int DirtBlocks;
    public int SandBlocks;
    public int StoneBlocks;

    public Text grassText;
    public Text dirtText;
    public Text sandText;
    public Text stoneText;

    public Transform grassPosition;
    public Transform dirtPosition;
    public Transform sandPosition;
    public Transform stonePositon;

    public Transform grassAmount;
    public Transform dirtAmount;
    public Transform sandAmount;
    public Transform stoneAmount;

    public Transform prefab;
    public GameObject player;

    public GameObject inventoryObject;

    public float speed = 100.0f;

	// Use this for initialization
	void Start () {

        Block1 = true;

        GrassBlocks = 10;
        DirtBlocks = 10;
        SandBlocks = 10;
        StoneBlocks = 10;
    }
	
	// Update is called once per frame
	void Update () {

        grassText.text = "Grass: " + GrassBlocks.ToString();
        dirtText.text = "Dirt: " + DirtBlocks.ToString();
        sandText.text = "Sand: " + SandBlocks.ToString();
        stoneText.text = "Stone: " + StoneBlocks.ToString();

        if (Input.GetKeyDown("1"))
        {
            Block1 = true;
            Block2 = false;
            Block3 = false;
            Block4 = false;
        }

        if (Input.GetKeyDown("2"))
        {
            Block1 = false;
            Block2 = true;
            Block3 = false;
            Block4 = false;
        }

        if (Input.GetKeyDown("3"))
        {
            Block1 = false;
            Block2 = false;
            Block3 = true;
            Block4 = false;
        }

        if (Input.GetKeyDown("4"))
        {
            Block1 = false;
            Block2 = false;
            Block3 = false;
            Block4 = true;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryObject.GetComponent<InventoryManagment>().SortInventory();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 v;
            if (PickThisBlock(out v, 4))
            {
                voxelChunk.SetBlock(v, 0);

                Instantiate(prefab, new Vector3(player.transform.position.x + 1, player.transform.position.y + 1, player.transform.position.z + 1), Quaternion.identity);
            }

        }

        else if (Input.GetButtonDown("Fire2") && Block1 == true && GrassBlocks > 0)
        {
            Vector3 v;
            if (PickEmptyBlock(out v, 4))
            {
                voxelChunk.SetBlock(v, 1);

                GrassBlocks -= 1;
            }
        }

        else if (Input.GetButtonDown("Fire2") && Block2 == true && DirtBlocks > 0)
        {
            Vector3 v;
            if (PickEmptyBlock(out v, 4))
            {
                voxelChunk.SetBlock(v, 2);

                DirtBlocks -= 1;
            }
        }

        else if (Input.GetButtonDown("Fire2") && Block3 == true && SandBlocks > 0)
        {
            Vector3 v;
            if (PickEmptyBlock(out v, 4))
            {
                voxelChunk.SetBlock(v, 3);

                SandBlocks -= 1;
            }
        }

        else if (Input.GetButtonDown("Fire2") && Block4 == true && StoneBlocks > 0)
        {
            Vector3 v;
            if (PickEmptyBlock(out v, 4))
            {
                voxelChunk.SetBlock(v, 4);

                StoneBlocks -= 1;
            }
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "GrassCube")
        {
            GrassBlocks += 1;
            Destroy(hit.gameObject);
        }
    }

    public bool PickThisBlock(out Vector3 v, float dist)
    {
        {
            v = new Vector3();
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, dist))
            {
                v = hit.point - hit.normal / 2;

                v.x = Mathf.Floor(v.x);
                v.y = Mathf.Floor(v.y);
                v.z = Mathf.Floor(v.z);
                return true;
            }

        }

        return false;
    }


    bool PickEmptyBlock(out Vector3 v, float dist)
    {
        {
            v = new Vector3();
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, dist))
            {
                v = hit.point + hit.normal / 2;

                v.x = Mathf.Floor(v.x);
                v.y = Mathf.Floor(v.y);
                v.z = Mathf.Floor(v.z);
                return true;
            }

        }
        return false;
    }

}
