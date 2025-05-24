using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsManager : MonoBehaviour
{
    private Dictionary<string, GameObject> rightHands = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> leftHands = new Dictionary<string, GameObject>();

    [SerializeField] private GameObject bareHandRight;
    [SerializeField] private GameObject spoonHandRight;

    [SerializeField] public GameObject bowlHandLeft;
    [SerializeField] public GameObject emptyHandLeft;

    private void Awake()
    {
        RegisterRightHand("BareHandRight", bareHandRight);
        RegisterRightHand("SpoonHandRight", spoonHandRight);

        RegisterLeftHand("BowlLeft", bowlHandLeft);
        RegisterLeftHand("EmptyHandLeft", emptyHandLeft);
    }

    // RIGHT HAND
    public void RegisterRightHand(string name, GameObject rightHand)
    {
        rightHands[name] = rightHand;
    }

    public void ShowRightHand(string rightHandName)
    {
        foreach(var rightHand in rightHands.Values)
        {
            rightHand.SetActive(false);
        }

        if(rightHands.ContainsKey(rightHandName))
        {
            rightHands[rightHandName].SetActive(true);
        }
    }

    // LEFT HAND
    public void RegisterLeftHand(string name, GameObject leftHand)
    {
        leftHands[name] = leftHand;
    }

    public void ShowLeftHand(string leftHandName)
    {
        foreach(var leftHand in leftHands.Values)
        {
            leftHand.SetActive(false);
        }

        if(leftHands.ContainsKey(leftHandName))
        {
            leftHands[leftHandName].SetActive(true);
        }
    }
}
