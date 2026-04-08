using UnityEngine;

public class DefaultLight : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float darknessLevel;
    public float darkenSpeed;

    private Color onColor = Color.yellow;
    private Color offColor = Color.grey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        darknessLevel += Time.deltaTime * darkenSpeed;
        if (darknessLevel > 1)
        {
            darknessLevel = 1;
        }

        meshRenderer.material.color = Color.Lerp(onColor, offColor, darknessLevel);
    }
}