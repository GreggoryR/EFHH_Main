///////////////////////////////////////////////////////////////////////////
//FileName: RotateObject.cs
//Author : Aladine - https://answers.unity.com/questions/716086/spin-a-2d-object-with-mouse-drag.html
//Description : Class for rotating objects - won't be using but still interesting
////////////////////////////////////////////////////////////////////////////
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] public float deltaRotation;
    [SerializeField] public float deltaLimit;
    [SerializeField] public float deltaReduce;
    [SerializeField] float previousRotation;
    [SerializeField] float currentRotation;
    [SerializeField] Transform ok;




    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            deltaRotation = 0f;
            previousRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            GameManager.instance.currentWheelRotation = currentRotation;
        }
        else if (Input.GetMouseButton(0))
        {
            currentRotation = angleBetweenPoints(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            deltaRotation = Mathf.DeltaAngle(currentRotation, previousRotation);
            if (Mathf.Abs(deltaRotation) > deltaLimit)
            {
                deltaRotation = deltaLimit * Mathf.Sign(deltaRotation);
            }
            previousRotation = currentRotation;
            ok.Rotate(Vector3.back, deltaRotation);
            GameManager.instance.currentWheelRotation = currentRotation;
        }
        else
        {
            ok.Rotate(Vector3.back, deltaRotation);
            deltaRotation = Mathf.Lerp(deltaRotation, 0, deltaReduce);
            GameManager.instance.currentWheelRotation = currentRotation;
        }

    }

    float angleBetweenPoints(Vector2 position1, Vector2 position2)
    {
        Vector2 fromLine = position2 - position1;
        Vector2 toLine = new Vector2(1, 0);

        float angle = Vector2.Angle(fromLine, toLine);

        Vector3 cross = Vector3.Cross(fromLine, toLine);

        // did we wrap around?
        if (cross.z > 0)
        {
            angle = 360f - angle;
        }

        return angle;
    }

}

    