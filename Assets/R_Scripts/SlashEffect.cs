using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    public GameObject slashParticlePrefab; // Reference to the slash particle prefab
    public Transform slashPointLeft; // Left slash point transform
    public float slashDuration = 2.0f; // Duration of the slash effect before it vanishes

    // Update is called once per frame
    void Update()
    {
        // Check for right mouse button press
        if (Input.GetMouseButtonDown(1))
        {
            // Play defend animation here

            // Instantiate slash particle effect at left slash point
            GameObject slashParticle = Instantiate(slashParticlePrefab, slashPointLeft.position, Quaternion.identity);
            Destroy(slashParticle, slashDuration);
        }
    }
}
