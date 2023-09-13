using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private float _pickUpRange = 2.6f;

    public PickupBehaviour playerPickupBehaviour;

    private Item _currentItem;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private GameObject _pickupTutoText;

    [SerializeField]
    private GameObject _itemName;

    [SerializeField]
    private Text _itemNameText;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _pickUpRange, _layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                _currentItem = hit.transform.GetComponent<Item>();
                _pickupTutoText.SetActive(true);
                _itemNameText.text = _currentItem.itemData.name;
                _itemName.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        else
        {
            _pickupTutoText.SetActive(false);
            _itemName.SetActive(false);
        }
    }
}
