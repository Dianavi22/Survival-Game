using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private float _pickUpRange = 2.6f;

    public PickupBehaviour playerPickupBehaviour;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _pickUpRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("PickUp");
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());

                }
            }
        }
    }
}
