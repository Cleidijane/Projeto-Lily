using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animaArvore : MonoBehaviour {
    public Sprite[] sprites;    // sprites utilizados
    public float framesPerSecond; //frequencia com que aconteceram os movimentos

    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer; //realiza a conversão de renderer para spriteRenderer já que este projeto usa objetos 2D
	}
	
	// Update is called once per frame
	void Update () {
        //alteração automática do frame
        int index = (int)(Time.timeSinceLevelLoad * framesPerSecond); //tempo do level iniciado multiplicado pelos frames
        index = index % sprites.Length; //tem a função de não permitir que o index ultrapasse o tamanho dos sprites(array). por uma divisão.

        spriteRenderer.sprite = sprites[index]; //alteração de sprites
    }
}
