using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountCubes : MonoBehaviour
{
    public int numCobes = 0;
    
    public TextMeshProUGUI textUI;


    public void increasePoints()
    {
        numCobes++;
        textUI.text = "CUBES: " + numCobes.ToString();
    }
}
