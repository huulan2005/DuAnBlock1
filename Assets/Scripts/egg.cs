using UnityEngine;

public class egg : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void HideEggShowlayer()
    {
        AudioManager.intance.ccrackeggclip();
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
