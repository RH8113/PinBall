using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour
{
    private float rotSpeed = 3f;
    void Start()
    {
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        
    }

    void Update()
    {
        this.transform.Rotate(0, this.rotSpeed, 0);
    }
}
