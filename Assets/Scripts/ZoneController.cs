using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public GameObject options;
    public GameObject[] zones;
    // Start is called before the first frame update
    void Start()
    {
        options.SetActive ( false );
        DisableZones ();
    

        GameEvent.instance.OnNextZone += EnableZone;
        GameEvent.instance.OnInitZones += EnableZone;


    }

    private void EnableZone ()
    {

        StartCoroutine ( Disappear () );
    }

    IEnumerator Disappear () {

        yield return new WaitForSeconds ( 2f );
        DisableZones ();
        zones [CameraMove.pivoteActual-2].SetActive ( true );

        if(zones[zones.Length-1].activeInHierarchy)
        {
            
            GameEvent.instance.PlayFinalMessage ();
            StartCoroutine ( ShowFinalOptions () );
        }

    }

    private IEnumerator ShowFinalOptions ()
    {
        yield return new WaitForSeconds ( 1f );
        options.SetActive ( true );
    }


    public void Salir () {
        Application.Quit ();
    }

    public void VolverAJugar () {
        CameraMove.pivoteActual = 2;
        EnableZone ();
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
