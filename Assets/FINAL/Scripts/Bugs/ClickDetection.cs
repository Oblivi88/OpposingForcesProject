using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetection : MonoBehaviour
{
    // detect if bugs are clicked on

    // values to check if a bug is clicked
    private LayerMask bugLayer;
    private Collider bugCollider;
    
    // bug HP (always 1, unless JumpBug is stuck to players face, in which case it is 10)
    public int bugHP;

    void Start()
    {
        // every time bug spawns in, set values
        bugHP = 1;
        bugLayer = LayerMask.GetMask("Bug");
        bugCollider = GetComponent<Collider>();
        // if collider is null, find it in a child object (this is for the JumpBug, the collider is on the spider, not the object the script is on)
        if (bugCollider == null)
        {
            bugCollider = GetComponentInChildren<SphereCollider>();
        }
    }

    void Update()
    {
        // if mouse is clicked, set a raycast, and detect if the collider of the object is a bug collider. If it is, take a way HP.
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
