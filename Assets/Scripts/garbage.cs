using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbage : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string garsound;

    FMOD.Studio.EventInstance EventInstance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    
        {
            EventInstance = FMODUnity.RuntimeManager.CreateInstance(garsound);
            EventInstance.start();
        }   

     
    
}
