using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class MainMenu : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHost(){
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("Plane", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void StartClient(){
        NetworkManager.Singleton.StartClient();
    }
}
