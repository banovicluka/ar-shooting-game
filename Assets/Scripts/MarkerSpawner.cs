using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MarkerSpawner : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager; // Assign via the inspector
    public GameObject angelPrefab;
    public GameObject devilPrefab;

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            SpawnObject(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            UpdateSpawnedObject(trackedImage);
        }

        foreach (var trackedImage in args.removed)
        {
            DestroySpawnedObject(trackedImage);
        }
    }

    private void SpawnObject(ARTrackedImage trackedImage)
    {
        if (trackedImage.referenceImage.name == "AngelMarker")
        {
            Instantiate(angelPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
        }
        else if (trackedImage.referenceImage.name == "DevilMarker")
        {
            Instantiate(devilPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
        }
    }

    private void UpdateSpawnedObject(ARTrackedImage trackedImage)
    {
        // Optional: Update object's position/rotation if marker is still detected.
        Debug.Log($"Updated {trackedImage.referenceImage.name}");
    }

    private void DestroySpawnedObject(ARTrackedImage trackedImage)
    {
        // Optional: Clean up if marker is removed or lost.
        Debug.Log($"Removed {trackedImage.referenceImage.name}");
    }
}

