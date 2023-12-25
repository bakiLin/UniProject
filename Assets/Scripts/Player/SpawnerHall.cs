using UnityEngine;

public class SpawnerHall : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3[] playerPos;

    private Vector3 rot = new Vector3(45, 90, 0f);

    private void Start()
    {
        if (PlayerPrefs.HasKey("HallDoor"))
        {
            string doorName = PlayerPrefs.GetString("HallDoor");

            if (doorName == "Door 3")
                Instantiate(player, playerPos[0], Quaternion.Euler(rot));

            if (doorName == "Door 5")
                Instantiate(player, playerPos[1], Quaternion.Euler(rot));
        } else
        {
            Instantiate(player, playerPos[0], Quaternion.Euler(rot));
        }
    }
}
