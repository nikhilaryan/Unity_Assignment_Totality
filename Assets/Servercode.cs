using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

/// <summary>
/// List item. To make a list of items list
/// </summary>
[System.Serializable]
public class listItem
{
    public list[] list;
    
}
/// <summary>
/// List. all the things in which values will be stored
/// </summary>
[System.Serializable]
public class list
{
    public int[] axes;
    public string type;
	/// <summary>
	/// The properties. uses newtonsoft.json library to make dictionary
	/// </summary>
	public IDictionary<string,string> properties =new Dictionary<string, string>();

}

public class Servercode : MonoBehaviour {

   //public string Baseurl = "https://0.0.0.0";
    const string jsonformatter = "jsonformatter.json";
    public GameObject Cubes;
  

	/// <summary>
	/// The mat. Uses this array to add material to instantiated cubes.
	/// </summary>
	[SerializeField]
	private Material[] mat;
    private void Awake()
    {

    }
    
    void Start()
    {
        string fileName = Path.Combine(Application.dataPath, jsonformatter);
        Debug.Log(jsonformatter);
        LoadJson(fileName);
    }
	/// <summary>
	/// Updates the properties. adds material and all other possible properties to the cubes.
	/// </summary> 
	/// <param name="box">Box.</param>
	/// <param name="Cubevalues">Cubevalues.</param>
	public void UpdateProperties(GameObject box, list Cubevalues)
	{
		foreach (Material m in mat) {
			if (m.name == Cubevalues.type) {
				//Material newmat = Resources.Load(Cubevalues.type, typeof(Material))as Material;
				box.GetComponent<Renderer>().material= m;
				if (m.name == "air") box.SetActive (false);
			}
		}
	}
	/// <summary>
	/// Createcube the specified Cubevalues. Instantiates cube at the given location and update properties.
	/// </summary>
	/// <param name="Cubevalues">Cubevalues.</param>
    public void Createcube(list Cubevalues)
    {
		GameObject box= Instantiate(Cubes, new Vector3(Cubevalues.axes[0], Cubevalues.axes[1], Cubevalues.axes[2]),Quaternion.identity);
		box.name = Cubevalues.type;
		foreach (var kvp  in Cubevalues.properties ) 
			{
			Debug.Log ("type: "+ Cubevalues.type+" "+kvp.Key+" "+kvp.Value);
		    }
		UpdateProperties (box, Cubevalues);

	}
	/// <summary>
	/// Loads the json. loads json from file and stores values in a list. stores items.
	/// </summary>
	/// <param name="fileName">File name.</param>
    public void LoadJson(string fileName)
    {
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            Debug.Log(json);
			//jsonutility doesn't work for making dictionary
           // listItem items = JsonUtility.FromJson<listItem>(json);
			listItem items =JsonConvert.DeserializeObject<listItem>(json);
            Debug.Log("Reached");
            Debug.Log(items.list.Length);
			for (int i = 0; i <items.list.Length; i++)
            {
               // Debug.Log("okaysomething");
                //Debug.Log(items.list[i].type);
                Createcube(items.list[i]);
            }
			
        }
    }

}



