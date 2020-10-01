using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour
{
    private float minimum = 1.0f;
    private float magSpeed = 10.0f;
    private float magnification = 0.07f;

    void Start()
    {

        
    }

    void Update()
    {
        this.transform.localScale = new Vector3
        (this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification,
        this.transform.localScale.y,
        this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
        
    }
}
