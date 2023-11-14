using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector2 positon, direction;
    GameObject laserObject;
    LineRenderer laser;
    List<Vector2> laserPoints = new List<Vector2>();
    public LaserBeam(Vector2 position,Vector2 direction, Material material)
    {
        this.laser = new LineRenderer();
        this.laserObject = new GameObject();
        this.laserObject.name = "Laser Beam";
        this.positon = position;
        this.direction = direction;

        this.laser = this.laserObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser .startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;

        CastRay(position,direction,laser);
    }
    
    void CastRay(Vector2 position,Vector2 direction, LineRenderer laser)
    {
        laserPoints.Add(position);
        Ray ray = new Ray(position,direction);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 30,5)) 
        {
            CheckHit(hit,direction,laser);
        }
        else
        {
            laserPoints.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int i = 0;
        laser.positionCount = laserPoints.Count;

        foreach (Vector2 point in laserPoints)
        {
            laser.SetPosition(i, point);
            i++;
        }
           
    }

    void CheckHit(RaycastHit hitInfo, Vector2 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Mirror") 
        {
            Vector2 pos = hitInfo.point;
            Vector2 dir = Vector2.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);

        }
        else
        {
            laserPoints.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
