using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    public AudioClip clip;
    LaserBeam beam;
    //int tmp = 0;

     void Start()
    {
        beam = new LaserBeam(gameObject.transform.position,-1 * gameObject.transform.right, material,clip);

    }

    // Update is called once per frame
    void Update()
    {
        beam.DestroyLaser();
        beam.CreateLaser(gameObject.transform.position, -1 * gameObject.transform.right, material);
        

    }
}
