using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public GameObject NextLevel;
    private Animator _playerAnimator;
    private Animator _camAnimator;
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
        _playerAnimator = player.GetComponent<Animator>();
        _camAnimator = cam.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            _playerController.ChangeDeadPosY(int.MinValue);
            _playerController.OnDisable();
            NextLevel.SetActive(true);

            switch (NextLevel.name)
            {
                case "Level2":
                    _camAnimator.SetBool("GoOrange", true);
                    _playerAnimator.Play("ChangeColorOrangePlayer");
                    break;

            }
        }
    }
}
