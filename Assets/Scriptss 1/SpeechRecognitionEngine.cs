using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    public string[] keywords = new string[] {"abelha", "abelha fique ai"};
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public Text results;
    public Image target;
	bool clicou;
	public bool colidiu;
	public Transform ground;

    protected PhraseRecognizer recognizer;
    protected string word = null;

    private void Start()

	{
		colidiu = false;
		clicou = false;
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "Você disse: <b>" + word + "</b>";
    }

    private void Update()
    {

			
		if (Input.GetMouseButtonUp (0)) {
			clicou = false;
		}

		if (Input.GetMouseButtonDown (0)) {
			clicou = true;
		}
		if (colidiu == false) {
				MoverLetra ();
		}
				}
        
	
	public void MoverLetra(){
		
		var x = target.transform.position.x;
		var y = target.transform.position.y;


		if (clicou == true) {
			target.transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		}

		if (clicou == false) {
				
			if (word == "abelha") {
				colidiu = Physics2D.Linecast (this.transform.position, ground.position, 1 << LayerMask.NameToLayer ("Lugar"));
				if (colidiu == true){
					target.transform.position = new Vector3 (x, y, 0);
			}
		}
			if (colidiu == false) {
				target.transform.position = new Vector3 (200, 50, 0);
			}
		}

			
	}





    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
