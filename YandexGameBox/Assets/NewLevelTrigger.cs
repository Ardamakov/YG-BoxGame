using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject LastLevel;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            _playerController.OnEnable();
            LastLevel.SetActive(false);
        }
    }
}
