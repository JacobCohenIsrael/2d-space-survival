using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // The object to be spawned
    public float explosionForce = 10f; // The force of the explosion
    public float explosionRadius = 5f; // The radius of the explosion

    public void SpawnObjects()
    {
        objectsToSpawn.ForEach(SpawnObject);
    }
    
    private void SpawnObject(GameObject objectPrefab)
    {
        // Spawn the objects
        
        var spawnedObject = Instantiate(objectPrefab, transform);
        spawnedObject.gameObject.transform.SetParent(null);
        // Apply explosion force to the spawned object
        var rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Random.insideUnitSphere * explosionForce, ForceMode2D.Impulse);
        }
    }
}