using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RackGenerate : MonoBehaviour
{
    public ShopUnlocks shopUnlocks;
    public GameObject rackOriginal;
    [SerializeField] TextMeshProUGUI activeRacksText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GenerateNewRack()
    {
        int racksPurchased = shopUnlocks.GetActiveRacks();
        int maxRacks = shopUnlocks.GetMaxRacks();
        GameObject[] racks = shopUnlocks.GetRacksArray();

        if (racksPurchased < maxRacks)
        {
            HashSet<int> existingRackIndices = new HashSet<int>();
            foreach (GameObject rack in racks)
            {
                if (rack != null)
                {
                    string[] parts = rack.name.Split('_');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int index))
                    {
                        existingRackIndices.Add(index);
                    }
                }
            }

            int idx = 1;
            while (existingRackIndices.Contains(idx))
            {
                idx++;
            }

            GameObject rackClone = Instantiate(rackOriginal, new Vector3(rackOriginal.transform.position.x, rackOriginal.transform.position.y,rackOriginal.transform.position.z - (0.50f * idx)), rackOriginal.transform.rotation);
            rackClone.name = "Rack_" + idx;
            rackClone.SetActive(true);
            rackClone.tag = "Rack";
            rackClone.GetComponent<MeshRenderer>().material.color = Color.red;
            shopUnlocks.SaveRacks();
            Debug.Log("Successfully Purchased Rack " + idx);
            PlayerPrefs.SetString("playerName", "");
        }
        else
        {
            Debug.Log("Max Racks Purchased");
        }
    }

    // Update is called once per frame
    void Update()
    {
        activeRacksText.text = shopUnlocks.GetActiveRacks().ToString() + " / " + shopUnlocks.GetMaxRacks().ToString();
    }
}
