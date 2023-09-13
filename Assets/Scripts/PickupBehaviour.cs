using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    private Item _currentItem;
    public void DoPickup(Item item)
    {
        _currentItem = item;

        playerAnimator.SetTrigger("Pickup");
        playerMoveBehaviour.canMove = false;

    }

    public void AddItemToInventory()
    {
        inventory.AddItem(_currentItem.itemData);
        Destroy(_currentItem.gameObject);
        _currentItem = null;

    }

    public void ReEnablePlayerMovement()
    {
        playerMoveBehaviour.canMove = true;

    }

}
