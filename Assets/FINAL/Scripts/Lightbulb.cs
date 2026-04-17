using UnityEngine;
using UnityEngine.InputSystem;

public class Lightbulb : MonoBehaviour
{
    // Get meshRenderer for the light objects
    private MeshRenderer meshRenderer;

    // values control how fast light turns on and off
    public float dimLevel;
    public float dimSpeed;
    private float onSpeed;

    // materials to lerp between
    public Material lightOn;
    public Material lightOff;

    // to check if light is clicked on
    private LayerMask lightLayer;
    private Collider lightCollider;

    void Start()
    {
        // set initial values
        meshRenderer = GetComponent<MeshRenderer>();
        dimLevel = 0;
        dimSpeed = 0.025f;
        onSpeed = 0.2f;
        meshRenderer.material = lightOn;
        lightLayer = LayerMask.GetMask("Lights");
        lightCollider = GetComponent<Collider>();
    }

    void Update()
    {
        // constantly dim light
        dimLevel += Time.deltaTime * dimSpeed;
        if (dimLevel > 1) // cap at 1
        {
            dimLevel = 1;
        }
        meshRenderer.material.Lerp(lightOn, lightOff, dimLevel);

        // if mouse is clicked, create a raycast
        // if the collider the raycast hits is a light collider, turn the light back on
        if (Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, float.MaxValue, lightLayer))
            {
                if (hitInfo.collider == lightCollider)
                {
                    dimLevel -= Time.deltaTime * onSpeed;
                }
            }
        }
    }
}
