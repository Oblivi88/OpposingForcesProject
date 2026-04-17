using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetection : MonoBehaviour
{
    private LayerMask bugLayer;
    private Collider bugCollider;
    public int bugHP;

    void Start()
    {
        bugHP = 1;
        bugLayer = LayerMask.GetMask("Bug");
        bugCollider = GetComponent<Collider>();

        if (bugCollider == null)
        {
            bugCollider = GetComponentInChildren<SphereCollider>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, float.MaxValue, bugLayer))
            {
                if (hitInfo.collider == bugCollider)
                {
                    bugHP--;
                }
            }
        }
    }
}
