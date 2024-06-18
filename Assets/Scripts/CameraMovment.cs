using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float moveSpeed;
    public Vector3 offset;
  
    void LateUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, 0, 0) + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, pos, moveSpeed);
        transform.position = smoothPos;
    }
}
