using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Position where the bullet will be spawned
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f; // Speed factor of the bullet
    // private KillTracker killTracker;

    void Start()
    {
        bulletSpeed = 25.0f;
        // killTracker = GameObject.FindObjectOfType<KillTracker>();
    }

    public void OnShootButtonPressed()
    {

            Debug.Log("Shoot button pressed"); // Debug log for confirmation

        // if (killTracker != null && killTracker.gameEnded)
        // {
        //     return; // Do not allow shooting if the game is over
        // }

        // var bullet = Instantiate(bulletPrefab); // Create a new bullet
        // bullet.transform.position = bulletSpawnPoint.position; // Set the bullet position to the bulletSpawnPoint position
        // bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed; // Shoot the bullet

        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
