using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    public int target = 144;

    void Awake()
    {
        Application.targetFrameRate = target;
    }
}
