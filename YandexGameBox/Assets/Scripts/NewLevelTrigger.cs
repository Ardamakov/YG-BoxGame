using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject lastLevel;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerController.ChangeDeadPosY((int)(player.transform.position.y - 20));
        _playerController.ChangeSpawnDirection(new Vector3(0, player.transform.position.y, player.transform.position.z));
        _playerController.OnEnable();
        lastLevel.SetActive(false);           
    }

}
