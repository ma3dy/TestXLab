using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    public float rollForce = 8f;
    public float stopDistance = 1.2f;

    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool isRolling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("[StoneMovement] На камне нет Rigidbody!");
        }
    }

    public void StartRolling(Vector3 target)
    {
        if (rb == null) return;

        isRolling = true;
        targetPosition = target;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Vector3 direction = (targetPosition - transform.position).normalized;
        if (direction.magnitude < 0.01f) return;

        rb.AddForce(direction * rollForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (!isRolling || rb == null) return;

        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance <= stopDistance)
        {
            isRolling = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = targetPosition;
        }
    }
}
