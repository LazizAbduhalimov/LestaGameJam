using UnityEngine;

public class BrickMb : MonoBehaviour
{
    public GameObject Default;
    public GameObject Destroyed;

    public void OnDisable()
    {
        SoundManager.Instance.PlayFX(AllSfxSounds.destroy);
    }
}