using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void play()
   {
        SceneManager.LoadScene(1);
   }

}
