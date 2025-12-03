using UnityEngine;

public class RoomRotator : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public bool rotatingLeft;
    public bool rotatingRight;

    void Update()
    {
        if (rotatingLeft)
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (rotatingRight)
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }

    public void RotateLeft() => rotatingLeft = true;
    public void RotateRight() => rotatingRight = true;
    public void StopRotate() => rotatingLeft = rotatingRight = false;
}
