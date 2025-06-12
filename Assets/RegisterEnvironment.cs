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
        activeCustomer = customerTrigger.GetCurrentCustomerAtRegister();
        customerName = activeCustomer.GetCustomerName();

        if (activeCustomer == null)
        {
            //do not display a customer
            return;
        }

        switch (customerName)
        {
            case "Joe":
                //display joe
                break;
            case "Goth":
                //display goth
                break;
        }
    }

    public Customer GetActiveCustomer()
    {
        return activeCustomer;
    }

}
