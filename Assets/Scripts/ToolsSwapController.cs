using UnityEngine;

public class ToolsSwapController : MonoBehaviour
{
    public Animator animator;
    public GameObject weaponAInstance;
    public GameObject weaponBInstance;

    private int currentToolId = 0;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (weaponAInstance != null)
            weaponAInstance.SetActive(true);
        if (weaponBInstance != null)
            weaponBInstance.SetActive(false);

        if (animator != null)
            animator.SetInteger("ToolType", currentToolId);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ToggleWeapon();
    }

    void ToggleWeapon()
    {
        currentToolId = (currentToolId == 0) ? 1 : 0;

        if (animator != null)
            animator.SetInteger("ToolType", currentToolId);

        if (weaponAInstance != null)
            weaponAInstance.SetActive(currentToolId == 0);

        if (weaponBInstance != null)
            weaponBInstance.SetActive(currentToolId == 1);
    }
}