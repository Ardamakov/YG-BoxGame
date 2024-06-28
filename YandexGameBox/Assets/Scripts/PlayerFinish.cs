using UnityEngine;
using System.Collections;

public class PlayerFinish : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public GameObject nextLevel;
    private PlayerController _playerController;
    private Renderer _playerRenderer;

    private void Awake()
    {
        _playerController = player.GetComponent<PlayerController>();
        _playerRenderer = player.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerController.ChangeDeadPosY(int.MinValue);
        _playerController.OnDisable();
        nextLevel.SetActive(true);
        StartCoroutine(ChangeColor(5));                  
    }

    private IEnumerator ChangeColor(int time)
    {
        yield return new WaitForSeconds(time);

        switch (nextLevel.name)
        {
            case "Level2":
                while (cam.backgroundColor != new Color(1f, 0.4745098f, 0f, 1f))
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    _playerRenderer.material.SetColor("_BaseColor", Color.Lerp(_playerRenderer.material.color, new Color(1f, 0.4745098f, 0f, 1f), Time.deltaTime));
                    cam.backgroundColor = Color.Lerp(cam.backgroundColor, new Color(1f, 0.4745098f, 0f, 1f), Time.deltaTime);
                }
                break;

        }
    }
}
