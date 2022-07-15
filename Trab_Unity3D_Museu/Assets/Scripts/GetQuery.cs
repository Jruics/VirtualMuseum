using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetQuery : MonoBehaviour
{
    public string[] items;

    public GameObject painting01;

    public SpriteRenderer spriteRenderer01;
    public Text title01;
    public Text artist01;
    public Text description01;
    public Text year01;
    public Text materials01;
    public Text interpretations01;
    public Text symbolism01;
    public Text story01;

    public List<GameObject> paintingChildren = new List<GameObject>();

    IEnumerator Start()
    {
        WWW itemsData = new WWW("http://localhost/vr/connection.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        print(GetDataValue(items[0], "ID")); // faz print ao id, é preciso depois guarda-lo em strings e fazer o mesmo para todos os quadros

        Texture2D tex = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        string picData = GetDataValue(items[0], "Imagem");
        byte[] bytes = System.Convert.FromBase64String(picData);
        tex.LoadImage(bytes);
        tex.Apply();
        // se for para usar sprites dá para criar ja aqui
        // object.sprite = Sprite.Create(tex, new Rect(0, 0, 124, 119), new Vector2(0f, 0f));
        spriteRenderer01.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 700);

        
        title01.text = "Title: " + GetDataValue(items[0], "Titulo");
        artist01.text = "Artist: " + GetDataValue(items[0], "Autor");
        description01.text = GetDataValue(items[0], "Descricao");
        year01.text = GetDataValue(items[0], "AnoCriacao");
        materials01.text = GetDataValue(items[0], "Materiais");
        interpretations01.text = GetDataValue(items[0], "Interpretacoes");
        symbolism01.text = GetDataValue(items[0], "Simbolismos");
        story01.text = GetDataValue(items[0], "HistoriaAutor");


        //painting01.transform.Find("Title").text.ToString() = "Title: " + GetDataValue(items[0], "Titulo");
        //print(painting01.transform.Find("BasicInfo"));
        //print(painting01.GetComponentInChildren(typeof(Text)) as Text);

        //WithForEachLoop();
        AddDescendantsWithTag(painting01.transform, "TitleTag", paintingChildren);
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }

    void Update()
    {
        
    }

    /*
    void WithForEachLoop()
    {
        foreach (Transform child in painting01)
            print("Foreach loop: " + child);
    }
    */

    private void AddDescendantsWithTag(Transform parent, string tag, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.tag == tag)
            {
                list.Add(child.gameObject);
                print(child.GetComponent<UnityEngine.UI.Text>().text);
            }
            AddDescendantsWithTag(child, tag, list);
        }
    }
}
