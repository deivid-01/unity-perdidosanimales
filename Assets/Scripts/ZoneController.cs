using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoneController : MonoBehaviour
{

    public GameObject[] zones;
    // Start is called before the first frame update
    void Start()
    {
        DisableZones ();
        zones [CameraMove.pivoteActual].SetActive ( true );

        GameEvent.instance.OnNextZone += EnableZone;
    }

    private void EnableZone ()
    {

        StartCoroutine ( Disappear () );
    }

    IEnumerator Disappear () {

        yield return new WaitForSeconds ( 2f );
        DisableZones ();
        zones [CameraMove.pivoteActual].SetActive ( true );

    }

    private void DisableZones ()
    {
        foreach ( GameObject zone in zones )
        {
            
            zone.SetActive ( false );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
