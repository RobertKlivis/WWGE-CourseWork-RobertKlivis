using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagment : MonoBehaviour {

    public Transform parentPanel;

    public List<string> itemNames;
    public List<int> itemAmounts;

    public GameObject startItem;

    public GameObject player;

    List<InventoryItemScript> inventoryList;

    private int Grass;
    private int Dirt;
    private int Sand;
    private int Stone;

    // Use this for initialization
    void Start()
    {
        itemAmounts.Add(Grass);
        itemAmounts.Add(Dirt);
        itemAmounts.Add(Sand);
        itemAmounts.Add(Stone);

        inventoryList = new List<InventoryItemScript>();
        for (int i = 0; i < itemNames.Count; i++)
        {
            GameObject inventoryItem = (GameObject)Instantiate(startItem);
            inventoryItem.transform.SetParent(parentPanel);
            inventoryItem.SetActive(true);

            InventoryItemScript iis = inventoryItem.GetComponent<InventoryItemScript>();
            iis.itemNameText.text = itemNames[i];
            iis.itemName = itemNames[i];
            iis.itemAmountText.text = itemAmounts[i].ToString();
            iis.itemAmount = itemAmounts[i];

            inventoryList.Add(iis);

            DisplayListInOrder();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Grass = player.GetComponent<PlayerScript>().GrassBlocks;
        Dirt = player.GetComponent<PlayerScript>().DirtBlocks;
        Sand = player.GetComponent<PlayerScript>().SandBlocks;
        Stone = player.GetComponent<PlayerScript>().StoneBlocks;
    }

    void DisplayListInOrder()
    {
        float yOffset = 55f;
        Vector3 startPosition = startItem.transform.position;
        foreach (InventoryItemScript iis in inventoryList)
        {
            iis.transform.position = startPosition;
            startPosition.y -= yOffset;
        }
    }

    public void SortInventory()
    {
        for (int i = 0; i < inventoryList.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i; j < inventoryList.Count; j++)
            {
                if (inventoryList[j].itemAmount < inventoryList[minIndex].itemAmount)
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                InventoryItemScript iis = inventoryList[i];
                inventoryList[i] = inventoryList[minIndex];
                inventoryList[minIndex] = iis;
            }
        }

        DisplayListInOrder();

    }
}
