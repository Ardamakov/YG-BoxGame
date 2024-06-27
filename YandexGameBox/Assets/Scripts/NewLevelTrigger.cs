using UnityEngine;

public class NewLevelTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject LastLevel;
    private PlayerController _playerController;
    private Renderer _playerRenderer;

    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
        _playerRenderer = player.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            switch (LastLevel.name)
            {
                case "Level1":
                    _playerRenderer.material.SetColor("_BaseColor", new Color(1f, 0.4745098f, 0f, 1f));
                    break;
            }

            _playerController.ChangeDeadPosY((int)(player.transform.position.y - 20));
            _playerController.ChangeSpawnDirection(new Vector3(0, player.transform.position.y, player.transform.position.z));
            _playerController.OnEnable();
            LastLevel.SetActive(false);           
        }

    }

}
