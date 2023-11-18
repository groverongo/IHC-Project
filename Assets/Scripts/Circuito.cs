using UnityEngine;

public class Circuito : MonoBehaviour
{
    public Transform[] posiciones;
    public GameObject carroPrefab; // Reference to the carro prefab

    void Awake()
    {
        // Call a method to instantiate and position the carro prefab.
        InstantiateAndPositionCarro(EleccionRuta.indice);
    }

    void Update()
    { 
    }

    void InstantiateAndPositionCarro(int indice_ruta)
    {
        // Check if there is at least one position.
        if (posiciones.Length > indice_ruta)
        {
            // Instantiate the carro prefab.
            GameObject carroInstance = Instantiate(carroPrefab, posiciones[indice_ruta].position, posiciones[indice_ruta].rotation);

        }
        else
        {
            Debug.LogWarning("No positions defined. Cannot instantiate and position carro.");
        }
    }

}
