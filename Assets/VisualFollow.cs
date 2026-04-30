using UnityEngine;
using UnityEngine.UIElements;

public class VisualFollow : MonoBehaviour
{

[SerializeField] private Rigidbody physicRoot;
[SerializeField] private Vector3 positionOffset;
[SerializeField] private float turnSpeed = 10f;


    void Update()
    {
        transform.position = physicRoot.position + positionOffset;

        Vector3 flatVelocity = physicRoot.linearVelocity;
        flatVelocity.y = 0f;

        if(flatVelocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(flatVelocity.normalized, Vector3.up);
            Vector3 euler = targetRotation.eulerAngles;
            Quaternion yawOnly = Quaternion.Euler(0f, euler.y, 0f);

            transform.rotation = Quaternion.Slerp(transform.rotation, yawOnly, turnSpeed * Time.deltaTime);
        }


    }

}
