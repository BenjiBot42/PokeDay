using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class player_sfx : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footSteps_wood;

    public void playFootstepSound()
    {
        soundFXManager.instance.PlaySFXClip(footSteps_wood[Random.Range(1,3)], transform, 0.5f);
    }
}
