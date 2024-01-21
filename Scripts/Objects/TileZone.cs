using UnityEngine;

public class TileZone : MonoBehaviour
{
    [SerializeField] private GameObject tile;

    void OnTriggerEnter2D(Collider2D other)
    {
        tile.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        tile.SetActive(false);
    }
}
