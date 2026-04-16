using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lightbulb : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float dimLevel;
    public float dimSpeed;
    private float onSpeed;

    public Material lightOn;
    public Material lightOff;

    private LayerMask lightLayer;
    private Collider lightCollider;

    void Start()
    {
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
        dimLevel += Time.deltaTime * dimSpeed;
        if (dimLevel > 1)
        {
            dimLevel = 1;
        }

        meshRenderer.material.Lerp(lightOn, lightOff, dimLevel);

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
