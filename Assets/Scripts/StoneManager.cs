using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform spawnPoint;
    public Transform stopPoint;

    private GameObject currentStone;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            OnButtonClick();
        }
    }

    public void OnButtonClick()
    {
        if (currentStone != null)
        {
            Destroy(currentStone);
        }

        currentStone = Instantiate(stonePrefab, spawnPoint.position, spawnPoint.rotation);

        StoneMovement movement = currentStone.GetComponent<StoneMovement>();
        if (movement != null)
        {
            movement.StartRolling(stopPoint.position);
        }
    }
}