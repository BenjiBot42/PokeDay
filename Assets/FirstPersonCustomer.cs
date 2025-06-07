using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCustomer : MonoBehaviour, IInteractable
{
    [SerializeField] private OrderManager orderManager;

    public void OnClick()
    {
        orderManager.TakeCustomerOrder();
        print("click");
    }
}
