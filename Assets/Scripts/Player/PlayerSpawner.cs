using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 enterPos;

    [SerializeField] private GameObject player;

    void Start()
    {
        if (PlayerPrefs.HasKey("firstSpawn"))
        {
            if (PlayerPrefs.GetInt("firstSpawn") == 0)
                Instantiate(player, startPos, Quaternion.Euler(45, 90, 0));
            else
                Instantiate(player, enterPos, Quaternion.Euler(45, 90, 0));
        }
    }
}
