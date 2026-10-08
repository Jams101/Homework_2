using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [Tooltip("Camera to which parallax is relative")]
    public GameObject parallaxCamera;

    [Tooltip("Level of parallax for this depth layer")]
    public float parallaxLevel;

    [Tooltip("The hero wizard game object reference")]
    public GameObject wizard;

    // potentially useful local variables:

    // the width of the background tile
    float backWidth;
    // the wizard's monobehavior compononent script
    WizardBehavior wizardBehavior;
    // the starting position of the background tile
    float xStart;

    // TODO: Add additional local variables as needed
    
    // Start is called before the first frame update
    void Start()
    {
        xStart  = transform.position.x;

        //Debug.Log("Starting position for layer with parallax " + parallaxLevel + " is " + xStart);

        backWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        wizardBehavior = wizard.GetComponent<WizardBehavior>();
    }

    // Update is called once per frame
    void Update()
    {              
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
