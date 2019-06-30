using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject Arcane, Fire, Water, Holy, Nature, Frost, Target;

    Vector3 onPlayer, onPlayerOther;

    public void RotateShield(GameObject instance)
    {
        instance.transform.Rotate(90, 0, 0);
    }

    public void PositionShield(GameObject instance)
    {
        instance.transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y - 0.24f, Target.transform.position.z);
    }

    private void Start()
    {
        //onPlayer = new Vector3(Target.transform.position.x, Target.transform.position.y -0.18f, Target.transform.position.z);
        //onPlayerOther = new Vector3(Target.transform.position.x, Target.transform.position.y - 0.18f, Target.transform.position.z);


    }

    public void ChangeArcane()
    {
        DestroyShield();
        var parent = GameObject.Find("Player").transform;
        var instance = Instantiate(Arcane, Target.transform.position, Quaternion.identity, parent) as GameObject;
        RotateShield(instance);
        PositionShield(instance);

    }

    public void ChangeFire()
    {
        DestroyShield();
        var parent = GameObject.Find("Player").transform;
        var instance = Instantiate(Fire, Target.transform.position, Quaternion.identity, parent) as GameObject;
        RotateShield(instance);
        PositionShield(instance);
    }

    public void ChangeWater()
    {
        DestroyShield();
        var parent = GameObject.Find("Player").transform;
        var instance = Instantiate(Water, Target.transform.position, Quaternion.identity, parent) as GameObject;
        RotateShield(instance);
        PositionShield(instance);
    }

    public void ChangeHoly()
    {
        DestroyShield();
        var parent = GameObject.Find("Player").transform;
        var instance = Instantiate(Holy, Target.transform.position, Quaternion.identity, parent) as GameObject;
        RotateShield(instance);
        PositionShield(instance);
    }

    public void ChangeNature()
    {
        DestroyShield();
        var parent = GameObject.Find("Player").transform;
        var instance = Instantiate(Nature, Target.transform.position, Quaternion.identity, parent) as GameObject;
        RotateShield(instance);
        PositionShield(instance);
    }

    public void ChangeFrost()
    {
        DestroyShield();
        var parent = GameObject.Find("Player").transform;
        var instance = Instantiate(Frost, Target.transform.position, Quaternion.identity, parent) as GameObject;
        RotateShield(instance);
        PositionShield(instance);
    }

    void DestroyShield()
    {
        Destroy(GameObject.Find("Fire(Clone)"));
        Destroy(GameObject.Find("Water(Clone)"));
        Destroy(GameObject.Find("Holy(Clone)"));
        Destroy(GameObject.Find("Nature(Clone)"));
        Destroy(GameObject.Find("Arcane(Clone)"));
        Destroy(GameObject.Find("Frost(Clone)"));
    }




}
