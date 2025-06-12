using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PerspectiveManager : MonoBehaviour
{
    [SerializeField] private GameObject thirdPersonPlayer;
    [SerializeField] private GameObject firstPersonPlayer;

    [SerializeField] private GameObject thirdPersonCam;
    [SerializeField] private GameObject firstPersonCam;

    [SerializeField] private CinemachineVirtualCamera firstPVirtualCamera;
    [SerializeField] private GameObject camFollowObject;

    //[SerializeField] private InputManager inputManager;
    [SerializeField] private AreaManager areaManager;
    [SerializeField] private HandsManager handsManager;

    private string currentTriggerTag;

    public void SetCurrentTriggerTag(string tag)
    {
        currentTriggerTag = tag;
    }

    public void Awake()
    {
        SwitchToThirdPerson();
    }

    public void SwitchToFirstPerson()
    {
        //switches on/off player objects
        thirdPersonPlayer.SetActive(false);
        firstPersonPlayer.SetActive(true);

        //switches on/off cameras
        thirdPersonCam.SetActive(false);
        firstPersonCam.SetActive(true);

        switch (currentTriggerTag)
        {
            case "BarTrigger":
                areaManager.ShowArea("Counter");
                handsManager.ShowRightHand("SpoonHandRight");
                handsManager.ShowLeftHand("BowlLeft");

                camFollowObject = handsManager.bowlHandLeft;
                break;

            case "RegisterTrigger":
                areaManager.ShowArea("Register");
                handsManager.ShowRightHand("BareHandRight");
                handsManager.ShowLeftHand("EmptyHandLeft");

                camFollowObject = handsManager.emptyHandLeft;
                break;

            case "FridgeTrigger":
                areaManager.ShowArea("Fridge");
                handsManager.ShowRightHand("BareHandRight");
                handsManager.ShowLeftHand("EmptyHandLeft");

                camFollowObject = handsManager.emptyHandLeft;
                break;
        }

        firstPVirtualCamera.Follow = camFollowObject.transform;
    }

    public void SwitchToThirdPerson()
    {
        areaManager.ShowArea("Restaurant");

        //switches on/off player objects
        thirdPersonPlayer.SetActive(true);
        firstPersonPlayer.SetActive(false);

        //switches on/off cameras
        thirdPersonCam.SetActive(true);
        firstPersonCam.SetActive(false);
    }
}