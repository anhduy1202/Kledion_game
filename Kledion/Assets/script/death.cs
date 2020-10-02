using UnityEngine;
public class death : MonoBehaviour
{
  public Transform spawnPoint;//Add empty gameobject as spawnPoint
    public float minHeightForDeath;
    public GameObject player; //Add your player

    void Update()
    {
        if (player.transform.position.y < minHeightForDeath) //if player y-axis position smaller than minheightfordeath
            player.transform.position = spawnPoint.position; //then return to spawnpoint
    }
}
