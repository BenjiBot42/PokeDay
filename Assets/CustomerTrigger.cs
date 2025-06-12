using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerTrigger : MonoBehaviour
{
//    [SerializeField] private BoxCollider2D CustomerRegisterTrig;

    [SerializeField] private bool isCustomerAtRegister = false;

    [SerializeField] private Customer currentCustomerAtRegister;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GameObject().tag == "Customer")
        {
            isCustomerAtRegister = true;
            currentCustomerAtRegister = other.GameObject().GetComponent<Customer>();
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GameObject().tag == "Customer")
        {
            isCustomerAtRegister = false;
            currentCustomerAtRegister = null;
        }
    }
    */

    public bool GetIsCustomerAtRegister()
    {
        return isCustomerAtRegister;
    }

    public Customer GetCurrentCustomerAtRegister()
    {
        return currentCustomerAtRegister;
    }
}
