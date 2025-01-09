using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;
using System.Collections.Generic;

public class ARNPCController : MonoBehaviour
{
    public GameObject PrefabEnemy;
    public GameObject PrefabAlly;
    [Range(0, 100)]
    public int enemyRate = 50;

    private ARPlaneManager arPlaneManager;
    private Dictionary<ARPlane, Coroutine> planeSpawnCoroutines = new Dictionary<ARPlane, Coroutine>();

    void Start()
    {
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnDestroy()
    {
        if (arPlaneManager != null)
        {
            arPlaneManager.planesChanged -= OnPlanesChanged;
        }
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            if (!planeSpawnCoroutines.ContainsKey(plane))
            {
                planeSpawnCoroutines[plane] = StartCoroutine(SpawnOnPlane(plane));
            }
        }

        foreach (var plane in args.removed)
        {
            if (planeSpawnCoroutines.ContainsKey(plane))
            {
                StopCoroutine(planeSpawnCoroutines[plane]);
                planeSpawnCoroutines.Remove(plane);
            }
        }
    }

    private IEnumerator SpawnOnPlane(ARPlane plane)
    {
        while (plane != null && plane.gameObject.activeSelf)
        {
            // Randomize spawn position within the bounds of the plane
            Vector3 spawnPosition = plane.transform.position + new Vector3(
                UnityEngine.Random.Range(-0.5f, 0.5f),
                0,
                UnityEngine.Random.Range(-0.5f, 0.5f)
            );

            // Instantiate either an enemy or ally NPC
            GameObject NPC = null;
            bool isEnemy = UnityEngine.Random.Range(0, 100) <= enemyRate;

            if (isEnemy)
            {
                NPC = Instantiate(PrefabEnemy, spawnPosition, Quaternion.identity);
            }
            else
            {
                NPC = Instantiate(PrefabAlly, spawnPosition, Quaternion.identity);
            }

            // Wait for 3 seconds
            yield return new WaitForSeconds(3f);

            // Destroy the NPC after 3 seconds
            Destroy(NPC);

            // Wait for another 3 seconds before spawning a new NPC
            yield return new WaitForSeconds(3f);
        }

        // Cleanup after plane is no longer available
        planeSpawnCoroutines.Remove(plane);
    }
}
