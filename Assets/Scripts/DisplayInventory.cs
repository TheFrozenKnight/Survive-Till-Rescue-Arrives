using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        CreateDisplay();        
    }
    void Update()
    {
        UpdatedDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            //var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            var obj = Instantiate(inventory.Container[i].item.prefab,transform,false);
            obj.gameObject.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            obj.gameObject.GetComponent<Image>().sprite = inventory.Container[i].item.icon;
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    public void UpdatedDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        { 
            if(itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, transform, false);
                obj.gameObject.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
                obj.gameObject.GetComponent<Image>().sprite = inventory.Container[i].item.icon;
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

}
