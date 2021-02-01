using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herosounds : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string Jump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            FMOD.Studio.EventInstance e = FMODUnity.RuntimeManager.CreateInstance(Jump);
            e.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));

            e.start();
            e.release();//Release each event instance immediately, there are fire and forget, one-shot instances. 
        }
    }

    void jumping()
    {


        
    }
}
