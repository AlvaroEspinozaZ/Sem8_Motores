using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assets/SORotarion", menuName = "Assets/Create/SORotarion", order = 0)]
public class SORotarion : ScriptableObject
{
    private Transform Planet;
    [SerializeField] float velocityX;
    [SerializeField] float velocityY;
    [SerializeField] float velocityZ;
    private Vector3 angulos;
    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    
    public void rotation()
    {
        angulos.y = angulos.y + velocityY * Time.deltaTime;
        angulos.x = angulos.x + velocityX * Time.deltaTime;
        angulos.z = angulos.z + velocityZ * Time.deltaTime;
        //rotation z-> x -> y
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * qx * qz;

        Planet.rotation = r;
    }
    public void GetTransform(Transform Planet)
    {
        this.Planet = Planet;
    }

}
