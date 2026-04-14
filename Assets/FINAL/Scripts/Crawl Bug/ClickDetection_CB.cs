using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetection_CB : MonoBehaviour
{
    private LayerMask bugLayer;
    private Collider bugCollider;
    public bool isSquashed;

    void Start()
    {
        bugLayer = LayerMask.GetMask("CrawlBug");
        bugCollider = GetComponent<Collider>();
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
                    isSquashed = true;
                }
            }
        }
    }
}
