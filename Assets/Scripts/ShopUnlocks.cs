using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;

public class ShopUnlocks : MonoBehaviour
{
    public int maxRacks = 3;
    public GameObject[] racks;
    public GameObject rackOriginal;
    // Start is called before the first frame update
    void Start()
    {
        LoadRacks();
        if (racks == null)
            racks = GameObject.FindGameObjectsWithTag("Rack");
    }

    public int GetActiveRacks()
    {
        return GameObject.FindGameObjectsWithTag("Rack").Length;
    }

    public int GetMaxRacks()
    {
        return maxRacks;
    }

    public void FillRackArray()
    {
        racks = GameObject.FindGameObjectsWithTag("Rack");
    }

    public void IncreaseMaxRacks()
    {
        maxRacks++;
    }
    public GameObject[] GetRacksArray()
    {
        return racks;
    }

    public void SaveRacks()
    {
        FillRackArray();
        foreach (GameObject rack in racks)
        {
            string objectName = rack.name;
            Vector3 position = rack.transform.position;
            PlayerPrefs.SetFloat(objectName + "_pos_x", position.x);
            PlayerPrefs.SetFloat(objectName + "_pos_y", position.y);
            PlayerPrefs.SetFloat(objectName + "_pos_z", position.z);
            PlayerPrefs.Save();
            PlayerPrefs.SetString(objectName + "_color", rack.GetComponent<MeshRenderer>().material.color.ToString());
            Debug.Log("Saved " + objectName);
        }
    }

    public void LoadRacks()
    {
        for (int i = 1; i <= maxRacks; i++)
        {
            string rackName = "Rack_" + i;
            if (PlayerPrefs.HasKey(rackName + "_pos_x"))
            {
                float x = PlayerPrefs.GetFloat(rackName + "_pos_x");
                float y = PlayerPrefs.GetFloat(rackName + "_pos_y");
                float z = PlayerPrefs.GetFloat(rackName + "_pos_z");
                string nameColor = PlayerPrefs.GetString(rackName + "_color");

                CreateRack(x, y, z, i, nameColor);
            }
        }
        FillRackArray();
    }

    public void CreateRack(float x, float y, float z, int index, string nameColor)
    {
        GameObject rackClone = Instantiate(rackOriginal, new Vector3(x, y, z), transform.rotation.normalized);
        rackClone.name = "Rack_" + index;
        rackClone.SetActive(true);
        rackClone.tag = "Rack";
        rackClone.GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log("CreateRack: " + rackClone.name);
    }
    public void RemoveRack(GameObject rack)
    {
        if (rack != null)
        {
            PlayerPrefs.DeleteKey(rack.name + "_pos_x");
            PlayerPrefs.DeleteKey(rack.name + "_pos_y");
            PlayerPrefs.DeleteKey(rack.name + "_pos_z");
            PlayerPrefs.DeleteKey(rack.name + "_color");
            Destroy(rack);
            FillRackArray();
        }
    }
}
