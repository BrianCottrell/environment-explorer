/*
Code by Thomas Suarez "tomthecarrot"
HoloHacks 2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceManager : MonoBehaviour {

	// Singleton reference
	public static VoiceManager instance;

	// Voice Objects
	private Dictionary<string, System.Action> keywords;
	private KeywordRecognizer recognizer;

	void Start() {
		// Set singleton reference
		VoiceManager.instance = this;

		// Instantiate dictionary for keywords
		keywords = new Dictionary<string, System.Action>();
	}

	public void AddKeyword(string keyword, System.Action action) {
		// Add a keyword to the dictionary
		keywords.Add(keyword, action);
	}

	public void MakeRecognizer() {
		// Make speech recognizer based on existing keywords
		//recognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register callback for voice recognition
		recognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

		// Start speech recognizer!
		recognizer.Start();
	}

	// @see http://through-the-interface.typepad.com/through_the_interface/2016/07/adding-voice-commands-and-spatial-mapping-to-our-unity-model-in-hololens.html
 	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction)) {
			keywordAction.Invoke();
		}
	}

}
