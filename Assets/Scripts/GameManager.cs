using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]  CameraFollow _cameraFollow;
    [SerializeField]  Camera _camera;
    
    
    void Awake()
    {
        _cameraFollow.Init(player);
        player.GetComponent<PlayerMovement>().Init(_camera);
    }
    
}
