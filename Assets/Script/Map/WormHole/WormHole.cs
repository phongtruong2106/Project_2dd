using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : NewMonobehavior
{

    protected string sceneName = "galaxyDemo";
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
    }

    protected virtual void LoadGalaxy()
    {
       // SceneManager.LoadScene(this.sceneName);
    }
}