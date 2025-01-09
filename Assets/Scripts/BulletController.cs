using UnityEngine;
using UnityEngine.XR.ARFoundation; // Import this namespace for ARPlane


public class BulletController : MonoBehaviour
{
    public float destroyTime = 3f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

       

        if (collision.gameObject.CompareTag("Enemy"))
        {
            scoreManager.AddScore(1);
        }
        else if (collision.gameObject.CompareTag("Ally"))
        {
            scoreManager.AddScore(-1);
        }

         if (collision.gameObject.GetComponent<ARPlane>() == null)
        {
            // Destroy the object the bullet collides with
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
