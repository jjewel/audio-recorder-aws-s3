using UnityEngine;
using AudioRecorder;
using UnityEngine.UI;
using System.IO;

public class VoiceRecorder : MonoBehaviour {
	 
	Recorder recorder;
	AudioSource audioSource;

	public Button RecordSoundButton = null;
	public Button StopRecordingSoundButton = null;
	public Button PlaySoundButton = null;
	public Button SaveSoundButton = null;

	public string fileName = "";


	public bool autoPlay;

	string log = "";

	void OnEnable()
	{
		recorder = new Recorder();
		Recorder.onInit += OnInit;
		Recorder.onFinish += OnRecordingFinish;
		Recorder.onError += OnError;
		Recorder.onSaved += OnRecordingSaved;
	}
	void OnDisable()
	{
		Recorder.onInit -= OnInit;
		Recorder.onFinish -= OnRecordingFinish;
		Recorder.onError -= OnError;
		Recorder.onSaved -= OnRecordingSaved;
	}

	//Use this for initialization  
	void Start()   
	{  
		audioSource = GameObject.FindObjectOfType<AudioSource>();
		recorder.Init();
		RecordSoundButton.onClick.AddListener(() => { RecordSound(); });
		StopRecordingSoundButton.onClick.AddListener(() => { StopRecordingSound(); });
		PlaySoundButton.onClick.AddListener(() => { PlaySound(); });
		SaveSoundButton.onClick.AddListener(() => { SaveSound(); });
	}  
	
	void RecordSound()
	{
		recorder.StartRecording(false, 60);
		RecordSoundButton.GetComponentInChildren<Text>().text = "Recording...";
		Debug.Log("Is Recording");
	}

	void StopRecordingSound()
	{
		recorder.StopRecording();
		RecordSoundButton.GetComponentInChildren<Text>().text = "Record Sound";
		Debug.Log("Stopped Recording");
	}

void PlaySound(){
	recorder.PlayRecorded(audioSource);
}

void SaveSound(){
	fileName = "Audio"+Random.Range(0, 1000)+".wav";
	recorder.Save(Application.persistentDataPath + Path.AltDirectorySeparatorChar + fileName,recorder.Clip);
}



	void OnGUI()   
	{  
		GUILayout.Label (log);

		if(recorder.IsReady)  
		{  
			if(!recorder.IsRecording)  
			{  
				// if(GUI.Button(new Rect(Screen.width/2-150, Screen.height/2-100, 300, 60), "Start"))  
				// {  
				// 	recorder.StartRecording(false,60);
				// }  
			}  
			else
			{  
				// if(GUI.Button(new Rect(Screen.width/2-150, Screen.height/2-100, 300, 60), "Stop"))  
				// {  
				// 	recorder.StopRecording();
				// }   
				
				// GUI.Label(new Rect(Screen.width/2-150, 50, 300, 60), "Recording...");  
			} 

			if(recorder.hasRecorded)
			{
				// if(GUI.Button(new Rect(Screen.width/2-150, Screen.height/2-30, 300, 60), "Play"))  
				// {  
				// 	recorder.PlayRecorded(audioSource);
				// } 
				// if(GUI.Button(new Rect(Screen.width/2-150, Screen.height/2+40, 300, 60), "Save"))  
				// {  
				// 	recorder.Save(System.IO.Path.Combine(Application.persistentDataPath,"Audio"+Random.Range(0,10000)+".wav"),recorder.Clip);
				// } 
			}
		}  
	}  

	void OnInit(bool success)
	{
		Debug.Log("Success : "+success);
		log += "\nSuccess";
	}

	void OnError(string errMsg)
	{
		Debug.Log("Error : "+errMsg);
		log += "\nError " + errMsg;
	}

	void OnRecordingFinish(AudioClip clip)
	{
		if(autoPlay)
		{
			recorder.PlayAudio (clip, audioSource);

			// or you can use
			//recorder.PlayRecorded(audioSource);
		}
	}

	void OnRecordingSaved(string path)
	{
		Debug.Log("File Saved at : "+path);
		log += "\nFile save at : "+path;
		recorder.PlayAudio (path, audioSource);
	}
}
