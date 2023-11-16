using UnityEngine;

public class Circuito : MonoBehaviour
{
    public Transform[] posiciones;
    public GameObject carroPrefab; // Reference to the carro prefab

    void Start()
    {
        // Call a method to instantiate and position the carro prefab.
        InstantiateAndPositionCarro();
    }

    void InstantiateAndPositionCarro()
    {
        // Check if there is at least one position.
        if (posiciones.Length > 0)
        {
            // Instantiate the carro prefab.
            GameObject carroInstance = Instantiate(carroPrefab);

            // Set the position of the top-level parent of the carro instance.
            carroInstance.transform.position = posiciones[0].position;

            // Adjust the local positions of the children to maintain their relative positions.
            AdjustChildrenLocalPositions(carroInstance.transform);
        }
        else
        {
            Debug.LogWarning("No positions defined. Cannot instantiate and position carro.");
        }
    }

    void AdjustChildrenLocalPositions(Transform parent)
    {
        // Iterate through all children of the parent.
        for (int i = 0; i < parent.childCount; i++)
        {
            // Get the current child.
            Transform child = parent.GetChild(i);

            // Calculate the local position relative to the parent.
            Vector3 localPosition = child.position - parent.position;

            // Set the local position of the child.
            child.localPosition = localPosition;

            // Recursively adjust local positions for nested children.
            AdjustChildrenLocalPositions(child);
        }
    }
}
