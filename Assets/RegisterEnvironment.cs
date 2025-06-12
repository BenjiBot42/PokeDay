using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterEnvironment : MonoBehaviour
{
    [SerializeField] private CustomerTrigger customerTrigger;
    [SerializeField] private Customer activeCustomer;
    private GameObject customerPrefab;
    [SerializeField] private string customerName;

    private void OnEnable()
    {
        if (activeCustomer == null) { return; }

        activeCustomer = customerTrigger.GetCurrentCustomerAtRegister();
        customerName = activeCustomer.GetCustomerName();

        switch (activeCustomer.GetCustomerName())
        {
            case "Joe":
                print("Joe");
                break;
            case "Goth":
                print("Goth");
                break;
        }
    }
}
