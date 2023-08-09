using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] GameObject previousScreen;
    [SerializeField] GameObject currentLevelScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            previousScreen.SetActive(true);

            if (previousScreen == currentLevelScreen)
            {
                Time.timeScale = 1;
            }
        }
    }
}
