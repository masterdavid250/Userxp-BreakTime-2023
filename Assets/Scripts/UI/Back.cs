using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] GameObject previousScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            previousScreen.SetActive(true);
        }
    }
}
