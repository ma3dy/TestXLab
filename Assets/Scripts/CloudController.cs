using UnityEngine;

public class CloudController : MonoBehaviour
{
    public Transform[] targets;
    public float speed = 8f;
    public ParticleSystem rainParticles;
    [Range(1f, 10f)] public float cloudHeightOffset = 3f;

    private int currentIndex = 0;
    private bool isMoving = false;
    private Vector3 targetPos;
    private float arrivalThreshold = 0.5f;

    void Start()
    {
        if (targets.Length > 0)
        {
            currentIndex = 0;
            targetPos = GetTargetPositionWithOffset(currentIndex);
            transform.position = targetPos;

            if (rainParticles != null)
                rainParticles.Play();
        }
    }

    Vector3 GetTargetPositionWithOffset(int index)
    {
        Vector3 basePos = targets[index].position;
        return new Vector3(basePos.x, basePos.y + cloudHeightOffset, basePos.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isMoving)
            {
                isMoving = true;
                if (rainParticles != null)
                    rainParticles.Stop();
            }
            else
            {
                isMoving = false;
                if (rainParticles != null)
                    rainParticles.Play();
            }
        }

        if (!isMoving || targets.Length == 0) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) <= arrivalThreshold)
        {
            transform.position = targetPos;
            isMoving = false;

            if (rainParticles != null)
                rainParticles.Play();

            currentIndex++;
            if (currentIndex >= targets.Length)
                currentIndex = 0;

            targetPos = GetTargetPositionWithOffset(currentIndex);
        }
    }
}