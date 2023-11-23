using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScpript : MonoBehaviour
{
    [SerializeField] GameObject object1;
    public bool isCollider = false;
    public bool oneTime = true;

    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;
    float duration = 2f;
    private void Start()
    {
        oneTime = true;
    }
    void Update()
    {

        // SprawdŸ, czy obiekt do przesuniêcia jest dostêpny
        if (isCollider && oneTime)
        {

            //Debug.Log("Collision with Object!");
            oneTime = false;
            StartCoroutine(MoveObject(new Vector3(x, y, z), duration));
        }
    }
    IEnumerator MoveObject(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = object1.transform.position;

        while (time < duration)
        {
            object1.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        object1.transform.position = targetPosition;
    }
}