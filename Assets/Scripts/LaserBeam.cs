using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserBeam
{
    Vector3 positon, direction;
    GameObject laserObject;
    LineRenderer laser;
    List<Vector3> laserPoints = new List<Vector3>();
    public static GameObject [] ctrl = new GameObject[5];
    public static int ctrlN = 1;
    bool tmp = true;
    public LaserBeam(Vector3 position,Vector3 direction, Material material)
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
        this.laser.endColor = Color.red;

        CastRay(position,direction,laser);
    }

    //We clear all point where lasser was created
    public void DestroyLaser()
    {
        laserPoints.Clear();
    }

    public void CreateLaser(Vector3 position, Vector3 direction, Material material)
    {
        
        this.positon = position;
        this.direction = direction;

        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.red;

        CastRay(position, direction, laser);
    }

    
    void CastRay(Vector3 position,Vector3 direction, LineRenderer laser)
    {
        laserPoints.Add(position);
        Ray ray = new Ray(position,direction);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 30,1)) 
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

        foreach (Vector3 point in laserPoints)
        {
            laser.SetPosition(i, point);
            i++;
        }
           
    }

    //Operation to check what laser hit
    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if(hitInfo.collider.gameObject.tag == "Mirror") 
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);

        }
        else if(hitInfo.collider.gameObject.tag == "RotMirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
            for(int i=0; i<ctrlN; i++)
            {
                if (hitInfo.collider.gameObject == ctrl[i])
                {
                    tmp = false;
                }
            }
            if (tmp && ctrlN < 4)
            {
                ctrl[ctrlN] = hitInfo.collider.gameObject;
                ctrlN++;
            }


        }
        if (hitInfo.collider.gameObject.tag =="Finish"){
            if (Input.GetKey(KeyCode.F))
            {
                PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene("NextLevel");
            }
            laserPoints.Add(hitInfo.point);
            UpdateLaser();
            
        }
        else if (hitInfo.collider.gameObject.tag == "Button")
        {
            hitInfo.collider.gameObject.GetComponent<ButtonScpript>().isCollider = true;
            laserPoints.Add(hitInfo.point);
            UpdateLaser();
        }
        else
        {
            laserPoints.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
