using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ViewTrigger : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PerspectiveManager perspectiveManager;

    private BoxCollider2D triggerCollider;

    private void Awake()
    {
        triggerCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GameObject().tag == "Player")
        {
            inputManager.ViewCanSwitch(true);
            perspectiveManager.SetCurrentTriggerTag(this.gameObject.tag);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.GameObject().tag == "Player")
        {
            inputManager.ViewCanSwitch(false);   
        }
    }
}
