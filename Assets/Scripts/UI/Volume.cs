using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image number;

    private void Start()
    {
        number.sprite = sprites[AudioManager.instance.volume];
    }

    public void IncreaseVolume()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");

        if (AudioManager.instance.volume != 10)
        {
            AudioManager.instance.volume++;
            number.sprite = sprites[AudioManager.instance.volume];
        }
    }

    public void DecreaseVolume()
    {
        FindObjectOfType<AudioManager>().Play("Button Click");

        if (AudioManager.instance.volume != 0)
        {
            AudioManager.instance.volume--;
            number.sprite = sprites[AudioManager.instance.volume];
        }
    }
}
