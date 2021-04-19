using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    void awake()
      {
          DontDestroyOnLoad(this.gameObject);
          Debug.Log("DDOL" + gameObject.name);
          

    }

}
