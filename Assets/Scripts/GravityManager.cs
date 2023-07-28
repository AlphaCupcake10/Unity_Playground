using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public static GravityManager Instance;
    public List<MassBody> MassBodies;

    public float G = 4;

    void Awake()
    {
        Instance = this;
    }

    public void AddToList(MassBody mb)
    {
        MassBodies.Add(mb);
    }
    public void RemoveFromList(MassBody mb)
    {
        MassBodies.Remove(mb);
    }

    void FixedUpdate()
    {
        for(int i = 0 ; i < MassBodies.Count ; i ++)
        {
            for(int j = 0 ; j < MassBodies.Count ; j ++)
            {
                if(i==j)continue;
                Vector2 Distance = MassBodies[j].transform.position - MassBodies[i].transform.position;
                float magnitude = G * MassBodies[i].rb.mass*MassBodies[j].rb.mass/Distance.sqrMagnitude;
                MassBodies[i].rb.AddForce(magnitude*Distance.normalized);
            }
        }
    }

}
