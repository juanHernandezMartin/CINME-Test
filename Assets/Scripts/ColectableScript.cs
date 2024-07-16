using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableScript : MonoBehaviour
{
    // Spin speed in degrees per second
    public float spinSpeed = 400f;
    public float timeToDisapear;
    public Renderer cubeRen;
    private bool activated = false;
    private AudioSource audi;


    public void Awake()
    {
        audi = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        // Generate a random rotation
        //float randomX = spinSpeed * Time.deltaTime;
        float randomY = spinSpeed * Time.deltaTime;
        //float randomZ = spinSpeed * Time.deltaTime;

        // Apply rotation to the cube
        transform.Rotate(0, randomY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !activated)
        {
            activated = true;
            other.gameObject.GetComponent<CountCubes>().increasePoints();
            audi.Play();
            StartCoroutine(makeCubeInvisible());
        }
    }


    IEnumerator makeCubeInvisible()
    {
        Color color = cubeRen.material.color;
        while(color.a > 0 )
        {
            color.a -= 1/timeToDisapear * Time.deltaTime;
            cubeRen.material.color = color;
            yield return null;
        }
        
        yield return null;
    }
}
