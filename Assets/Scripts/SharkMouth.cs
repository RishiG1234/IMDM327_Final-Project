using UnityEditor.Build.Content;
using UnityEngine;

public class SharkMouth : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            gameManager.FishEaten();   // tell GameManager a fish was eaten
            Destroy(other.gameObject); // remove the fish
        }
    }
}
