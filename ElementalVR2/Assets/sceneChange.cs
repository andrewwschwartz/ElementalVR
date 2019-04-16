using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class sceneChange : MonoBehaviour {

    public Transform endPosition;
    public Player player;
    // Update is called once per frame
    void Update () {

        if (this.gameObject.transform.position == endPosition.position)
        {
            print("new scene");
            Destroy(player);
            SceneManager.LoadScene("Assets/Scenes/trainRoom3.unity");
            
        }
	}
}
