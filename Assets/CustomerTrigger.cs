using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider2D CustomerRegisterTrig;

    private bool customerAtRegister = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Customer")
        {
            customerAtRegister = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Customer")
        {
            customerAtRegister = false;
        }
    }

    public bool CustomerAtRegister()
    {
        return customerAtRegister;
    }
}
