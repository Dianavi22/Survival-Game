using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject _inventoryPanel;

    [SerializeField]
    private Transform _inventorySlotsParent;

    const int InventorySize = 24;

    private void Start()
    {
        RefreshContent();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
        }
    }
    public void AddItem(ItemData item)
    {
        content.Add(item);
        RefreshContent();
    }

    public void CloseInventory()
    {
        _inventoryPanel?.SetActive(false);
    }

   private void RefreshContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            _inventorySlotsParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite = content[i].visual;
        }
    }

    public bool IsFull()
    {
        return InventorySize == content.Count;
    }
}
