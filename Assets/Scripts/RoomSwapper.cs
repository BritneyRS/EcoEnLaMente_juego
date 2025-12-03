using UnityEngine;

public class RoomSwapper : MonoBehaviour
{
    public Transform[] rooms;

    public void SwapRooms(int a, int b)
    {
        Vector3 temp = rooms[a].position;
        rooms[a].position = rooms[b].position;
        rooms[b].position = temp;
    }
}
