using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;
    //int tmp = 0;

     void Start()
    {
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);

    }

    // Update is called once per frame
    void Update()
    {
        beam.DestroyLaser();
        beam.CreateLaser(gameObject.transform.position, gameObject.transform.right, material);
    }
}
