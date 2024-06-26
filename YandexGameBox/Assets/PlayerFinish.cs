using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
    public GameObject player;
    public GameObject NextLevel;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            _playerController.OnDisable();
            NextLevel.SetActive(true);
        }
    }
}
