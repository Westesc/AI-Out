using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScpript : MonoBehaviour
{
    [SerializeField] GameObject object1;
    [SerializeField] GameObject object2;
    [SerializeField] GameObject object3;
    public bool isCollider = false;
    public bool oneTime = true;

    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;

    [SerializeField] float x1;
    [SerializeField] float y1;
    [SerializeField] float z1;

    [SerializeField] float x2;
    [SerializeField] float y2;
    [SerializeField] float z2;
    float duration = 10f;
    private SwitchCamera switchCamera;
    int indexCamera;
    private void Start()
    {
        oneTime = true;
        switchCamera = FindObjectOfType<SwitchCamera>(); 
    }
    void Update()
    {
        if (isCollider && oneTime)
        {
            if (object2 != null)
            {
                Task.Delay(1000);
                StartCoroutine(MoveObject(new Vector3(x1, y1, z1), duration, object2));
            }
            if (object3 != null)
            {
                Task.Delay(1000);
                StartCoroutine(MoveObject(new Vector3(x2, y2, z2), duration, object3));
            }
            Debug.Log("Collision with Object!");
            oneTime = false;
            Task.Delay(1000);
            StartCoroutine(MoveObject(new Vector3(x, y, z), duration,object1));
        }
    }
    IEnumerator MoveObject(Vector3 targetPosition, float duration, GameObject obiekt)
    {
        float time = 0;
        Vector3 startPosition = obiekt.transform.position;

        while (time < duration)
        {
            obiekt.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        obiekt.transform.position = targetPosition;
    }
}