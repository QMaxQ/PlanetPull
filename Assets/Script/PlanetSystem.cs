using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystem: MonoBehaviour, IOrbitalCenter
{
    Transform starTransform;
    GameObject planetPrefab;
    List<Planet> planets = new List<Planet>();
    // Start is called before the first frame update
    void Start()
    {
        planetPrefab = Resources.Load("Planet") as GameObject;
        starTransform = this.transform;
        Generate();
    }

    public void AddOrbitalBody()
    {
        Vector3 starPos = starTransform.position;
        Vector3 vector3 = new Vector3(planets.Count + 1 + starPos.x, starPos.y, starPos.z);
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        Planet planet = Instantiate(planetPrefab, vector3, quaternion, starTransform).GetComponent<Planet>();
        planet.SetParam(starTransform, planets.Count + 1);
        planets.Add(planet);    
    }

    public void AddOrbitalBody(Planet planet)
    {
            
    }

    public void Generate()
    {
        int count = 5/*Random.Range(2, 4)*/;
        for (int i = 0; i < count; i++)
        {
            AddOrbitalBody();
        }
    }
}
