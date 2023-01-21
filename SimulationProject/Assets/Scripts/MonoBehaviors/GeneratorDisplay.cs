using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GeneratorDisplay : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    Generator generator;
    TextMeshPro text;
    SpriteRenderer iconRenderer;
    private void Awake()
    {
        text = this.GetComponentInChildren<TextMeshPro>();
        iconRenderer = this.GetComponentInChildren<SpriteRenderer>();
        if (generator == null)
        {
            generator = this.GetComponentInParent<Generator>();
        }
        if (target == null) {
            target = Camera.main.transform;
        }
        iconRenderer.sprite = generator.generator.resource.icon;
    }
    void Update()
    {
        this.transform.LookAt(this.transform.position - target.position);
        if (generator.currentSpawned != generator.maxSpawned)
        {
            text.text = "[" + generator.currentSpawned + " / " + generator.maxSpawned + "]";
        }
        else
        {
            text.text = "FULL!\n"+ "[" + generator.currentSpawned + " / " + generator.maxSpawned + "]";
        }
    }
}
