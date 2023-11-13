using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Line OF Renderer
    public LineRenderer LineOfSight;

    public int reflections;
    public float MaxRayDistance;
    private bool isLasserActive = false;
    public LayerMask LayerDetection;
    public float reflectOffset = 0.1f;
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        if (LineOfSight != null)
        {
            LineOfSight.positionCount = 1;
            LineOfSight.SetPosition(0, transform.position);
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);
        // Ray
        Ray2D ray = new Ray2D(transform.position, transform.right);

        bool isMirror = false;
        Vector2 mirrorHitPoint = Vector2.zero;
        Vector2 mirrorHitNormal = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.E))
        {
            isLasserActive = !isLasserActive;
            if (LineOfSight != null)
            {
                LineOfSight.enabled = isLasserActive;
            }
        }
        if (isLasserActive == true)
        {
            for (int i = 0; i < reflections; i++)
             {
          
                LineOfSight.positionCount += 1;

                if (hitInfo.collider != null)
                {
                    LineOfSight.SetPosition(LineOfSight.positionCount - 1, hitInfo.point - ray.direction * reflectOffset);

                    isMirror = false;
                    if (hitInfo.collider.CompareTag("Mirror"))
                    {
                        mirrorHitPoint = (Vector2)hitInfo.point;
                        mirrorHitNormal = (Vector2)hitInfo.normal;
                        hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * reflectOffset, Vector2.Reflect(hitInfo.point - ray.direction * reflectOffset, hitInfo.normal), MaxRayDistance, LayerDetection);
                        isMirror = true;
                    }
                    else
                        break;
                }
                else
                {
                    if (isMirror)
                    {
                        LineOfSight.SetPosition(LineOfSight.positionCount - 1, mirrorHitPoint + Vector2.Reflect(mirrorHitPoint, mirrorHitNormal) * MaxRayDistance);
                        break;
                    }
                    else
                    {
                        LineOfSight.SetPosition(LineOfSight.positionCount - 1, transform.position + transform.right * MaxRayDistance);
                        break;
                    }
                }
            }
        }

    }
}
/*public class Laser : MonoBehaviour
{
    [SerializeField] private float distance = 100;
    public Transform LaserPoint;
    public LineRenderer m_line;
    Transform m_transform;
    private bool isLasserActive = false;
    private int maxReflections = 5; // Maksymalna liczba odbiæ lasera
    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            isLasserActive = !isLasserActive;
            if (m_line != null)
            {
                m_line.enabled = isLasserActive;
            }
        }
        if (isLasserActive == true)
        {
            ShootLaser();
        }
    }
    void ShootLaser()
    {
        if (LaserPoint != null)
        {
            if (Physics2D.Raycast(m_transform.position, transform.right))
            {
                RaycastHit2D _hit = Physics2D.Raycast(LaserPoint.position, transform.right);
                Draw2DRay(LaserPoint.position, _hit.point);
            }
            else
            {
                Draw2DRay(LaserPoint.position, LaserPoint.transform.right * distance);
            }
        }
    }

    void Draw2DRay(Vector2 position1, Vector2 position2)
    {
        m_line.SetPosition(0, position1);
        m_line.SetPosition(1, position2);
    }
    void checkHit(RaycastHit2D hit, Vector3 direction)
    {
        if(hit.collider.gameObject.tag == "Mirror")
        {
            Vector3 pos = hit.point;
            Vector3 dir = Vector3.Reflect(direction, hit.normal);
         
        }
    }
}*/
