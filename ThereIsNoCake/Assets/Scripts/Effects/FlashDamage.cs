using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{  
    public Material _flashMaterial;
    private Material _defaultMaterial;
    private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _defaultMaterial = _sprite.material;
        //_flashMaterial = Resources.Load("WhiteFlash", typeof(Material)) as Material;        
    }

    // Update is called once per frame
    public void SetFlashDamage()
    {
        _sprite.material = _flashMaterial;
        Invoke("SetDefaultMaterial", 0.3f);
    }
    
    private void SetDefaultMaterial() 
    {
        _sprite.material = _defaultMaterial;
    } 
}
