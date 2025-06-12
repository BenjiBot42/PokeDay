using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCustomer : MonoBehaviour, IInteractable
{
    [SerializeField] private OrderManager orderManager;
    [SerializeField] private RegisterEnvironment registerEnvironment;

    public void OnClick()
    {
        if (orderManager.GetOrderInHand() == false)
        {
            
            
                orderManager.TakeCustomerOrder();
            
        }

        else if (orderManager.GetOrderInHand() == true)
        {
            orderManager.FulfillCustomerOrder();
        }
    }
}
