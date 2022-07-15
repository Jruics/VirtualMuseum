using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPaintings : MonoBehaviour
{
    public string[] items;

    public GameObject painting01;
    public GameObject paintingsParent;

    public List<GameObject> paintingChildren = new List<GameObject>();

    public List<GameObject> paintings01 = new List<GameObject>();
    public List<GameObject> paintings02 = new List<GameObject>();
    public List<GameObject> paintings03 = new List<GameObject>();
    public List<GameObject> paintings04 = new List<GameObject>();

    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/vr/connection.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split('$');
        print(GetDataValue(items[0], "ID"));

        SetLists(paintingsParent.transform, "TitleTag", paintingChildren);
        AutoAddPaintings(paintings01, paintings02, paintings03, paintings04);
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetLists(Transform parent, string tag, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag == "Type01")
            {
                paintings01.Add(child.gameObject);
            }
            if (child.gameObject.tag == "Type02")
            {
                paintings02.Add(child.gameObject);
            }
            if (child.gameObject.tag == "Type03")
            {
                paintings03.Add(child.gameObject);
            }
            if (child.gameObject.tag == "Type04")
            {
                paintings04.Add(child.gameObject);
            }
            SetLists(child, tag, list);
        }
    }

    private void AutoAddPaintings(List<GameObject> room01, List<GameObject> room02, List<GameObject> room03, List<GameObject> room04)
    {
        int i = 0;
        
        foreach (GameObject parent in room01)
        {
            AddDescendantsWithTag(parent.transform, "TitleTag", paintingChildren, i);
            i++;
        }
        foreach (GameObject parent in room02)
        {
            AddDescendantsWithTag(parent.transform, "TitleTag", paintingChildren, i);
            i++;
        }
        foreach (GameObject parent in room03)
        {
            AddDescendantsWithTag(parent.transform, "TitleTag", paintingChildren, i);
            i++;
        }
        foreach (GameObject parent in room04)
        {
            AddDescendantsWithTag(parent.transform, "TitleTag", paintingChildren, i);
            i++;
        }
    }

    private void AddDescendantsWithTag(Transform parent, string tag, List<GameObject> list, int i)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag == "TitleTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = "Title: " + GetDataValue(items[i], "Titulo");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "ArtistTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = "Artist: " + GetDataValue(items[i], "Autor");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "YearTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = GetDataValue(items[i], "AnoCriacao");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "MaterialsTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = GetDataValue(items[i], "Materiais");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "CreatorTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = GetDataValue(items[i], "HistoriaAutor");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "InterpretationsTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = GetDataValue(items[i], "Interpretacoes");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "SymbolismTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = GetDataValue(items[i], "Simbolismos");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "DescriptionTag")
            {
                list.Add(child.gameObject);
                child.GetComponent<UnityEngine.UI.Text>().text = GetDataValue(items[i], "Descricao");
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            if (child.gameObject.tag == "ArtTag")
            {
                Texture2D tex = createTex(i);
                child.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 700);
            }
            if (child.gameObject.tag == "FrameTag")
            {
                Texture2D tex = createTex(i);
                child.gameObject.transform.localScale += new Vector3(tex.width * 0.007f, tex.height * 0.007f, 0);
                switch (GetDataValue(items[i], "FrameNumber"))
                {
                    case "4":
                        child.GetComponent<Renderer>().material.color = Color.red;
                        break;
                    case "3":
                        child.GetComponent<Renderer>().material.color = Color.blue;
                        break;
                    case "2":
                        child.GetComponent<Renderer>().material.color = Color.yellow;
                        break;
                    case "1":
                        child.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                    default:
                        print("Missing Color");
                        break;
                }
            print("Cube Ran");
            }
            //print("Ran Descendants");
            AddDescendantsWithTag(child, tag, list, i);
        }
    }

    private Texture2D createTex(int i)
    {
        Texture2D tex = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        string picData = GetDataValue(items[i], "Imagem");
        byte[] bytes = System.Convert.FromBase64String(picData);
        tex.LoadImage(bytes);
        tex.Apply();

        return tex;
    }
}
