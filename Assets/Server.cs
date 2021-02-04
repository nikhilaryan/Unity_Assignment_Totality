using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Server : MonoBehaviour
{
    public string Baseurl = "https://0.0.0.0";
    const string jsonformatter = "jsonformatter.txt";

    private void Awake()
    {
        
    }
    public class ListItem
    {
        public Values[] Values;
    }
    public class Values
    {
        public string type;
        public string properties;
        public Vector3 axes;
    }
    void Start()
    {
        string fileName = Path.Combine(Application.dataPath, jsonformatter);
        LoadJson(fileName);
    }
    public void LoadJson(string fileName)
    {
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            ListItem items = JsonUtility.FromJson<ListItem>(json);
            
            
            for(int i=0;i<items.Values.Length;i++)
            {
                Debug.Log(items.Values[i]);
            }
            
            //cachedFilteredList = items.Values.ToList();
            //totalNoPages = Mathf.CeilToInt(cachedFilteredList.Count / (float)bottomPanelTileCount);
            //if (totalNoPages <= 1)
            //{
            //    previousPage.gameObject.SetActive(false);
            //    nextPage.gameObject.SetActive(false);
            //}
            //int setPage = (selectedPage.Value > GetLastPage()) ? GetLastPage() : selectedPage.Value;
            //setPage = (setPage < 0) ? 0 : setPage;
            //selectedPage.SetValueAndForceNotify(setPage);
        }
    }

}
