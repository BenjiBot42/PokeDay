using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;

    private Vector2 bowlMovement;
    private Vector2 rightHandMovement;

    [SerializeField] private Rigidbody2D bowlRB;
    [SerializeField] private float bowlSpeed;

    private float rHandXOffset = -0.55f;
    private float rHandYOffset = 0.55f;

    private void Update()
    {
        //move right hand to mouse position
        rightHandMovement = Camera.main.ScreenToWorldPoint(InputManager.MousePosition);
        rightHand.transform.position = new Vector2(rightHandMovement.x - rHandXOffset, rightHandMovement.y - rHandYOffset);

        //move bowl with WASD
        bowlMovement.Set(InputManager.BowlMovement.x, InputManager.BowlMovement.y);

        bowlRB.velocity = bowlMovement * bowlSpeed;
    }
}
