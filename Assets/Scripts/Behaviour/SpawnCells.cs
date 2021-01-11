using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCells : MonoBehaviour
{
    public List<Sprite> cellSprites;
    public AnimationClip cellPath;
    public string sortingLayer;

    public GameObject cellPrefab;

    public Transform spawnArea;

    public float delay;
    public float step;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            yield return new WaitForSeconds(step);
            Generate();
        }
    }

    void Generate()
    {
        var go = Instantiate(cellPrefab, transform);
        var incr = Random.insideUnitCircle * spawnArea.lossyScale[0];

        go.transform.position = go.transform.position + new Vector3(incr.x, incr.y, 0);
        
        var anim = go.GetComponentInChildren<Animation>();
        anim.clip = cellPath;
        anim.Stop();
        anim.Play();
        
        var renderers = go.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            if (renderer.gameObject.name == "Cell")
                renderer.sprite = cellSprites[Random.Range(0, cellSprites.Count)];
            renderer.sortingLayerName = sortingLayer;
        }
    }
}
