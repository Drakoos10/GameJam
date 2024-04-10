using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject botonResume;
    public GameObject Player;
    public GameObject ilu1;
    public GameObject ilu2;
    public GameObject ilu3;

    public void CambiarScene(string sceneName){
    SceneManager.LoadScene(sceneName);
     Time.timeScale = 1f;
}
public void pausa(){
    Time.timeScale = 0f;
    botonPausa.SetActive(false);
    botonResume.SetActive(true);
}
public void resume(){
    Time.timeScale = 1f;
    botonPausa.SetActive(true);
    botonResume.SetActive(false);
}
    private void Update()
    {
        if(ilu1 !=null && ilu2 != null && ilu3 !=null)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float salto = Input.GetAxisRaw("Jump");

            if (horizontal > 0)
            {
                ilu1.SetActive(true);
                ilu2.SetActive(false);
            }
            else if (horizontal < 0)
            {
                ilu1.SetActive(false);
                ilu2.SetActive(true);
            }
            else
            {
                ilu1.SetActive(false);
                ilu2.SetActive(false);
            }

            if (salto > 0)
            {
                ilu3.SetActive(true);
            }
            else
            {
                ilu3.SetActive(false);
            }
        }
        
    }

}
