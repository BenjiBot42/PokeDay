using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCustomer : MonoBehaviour, IInteractable
{
    [SerializeField] private OrderManager orderManager;

    private bool orderTaken = false;

    public void OnClick()
    {
        if (orderManager.GetOrderInHand() == false)
        {
            if (orderTaken) { return; }

            else if (!orderTaken)
            {
                orderManager.TakeCustomerOrder();
                orderTaken = true;
            }
        }

        else if (orderManager.GetOrderInHand() == true)
        {
            orderManager.FulfillCustomerOrder();
        }
    }
}
