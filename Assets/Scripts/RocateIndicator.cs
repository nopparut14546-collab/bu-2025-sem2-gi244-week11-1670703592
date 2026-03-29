using UnityEngine;

public class RotateIndicator : MonoBehaviour
{
    public Transform target;             
    public Vector3 offset = new Vector3(0f, -0.4f, 0f);
    public float rotateSpeed = 120f;
    public Vector3 baseRotation = Vector3.zero; 

    private float currentY;

    void Update()
    {
        if (target != null)
        {
            // ????????????????? ?????????????????????
            transform.position = target.position + offset;
        }

        currentY += rotateSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(
            baseRotation.x,
            baseRotation.y + currentY,
            baseRotation.z
        );
    }
}