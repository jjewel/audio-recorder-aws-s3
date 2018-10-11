Voice Recorder

Audio Recorder for unity is a great plugin to record your own audio and use in game.
Sometimes we need our own voice for game but can’t do this, therefore, we are releasing a VoiceRecorder for you. This is fully optimize and supported for Android, iOS, Windows, MAC. Unity Pro is not require to use this plugin.
Below is the Integration and How To Use guide for you.
Integration Guide-
1). Import AudioRecorder plugin in your project
2). Make sure following files are there:
/Assets/Plugins/AudioRecorder.dll
/Assets/Example folder
/Assets/Documentation folder
3). There should be a AudioSource in your scene, if not then follow these steps after selecting Main Camera:
Add Component > Audio > Audio Source
Note : You can put Audio source on any game object in the scene.
4). Integration Done

How to use-
1). Create a instance of AudioRecorder class
AudioRecorder  recorder = new AudioRecorder();
2). Setup events
- OnInit fires when audio recorder initialised.
Recorder.onInit += OnInit;
void OnInit(bool success){

}

- OnRecordingFinish fire when recording finished.
Recorder.onFinish += OnRecordingFinish;
void OnRecordingFinish(AudioClip clip){	
    if(autoPlay){
        recorder.PlayAudio (clip, audioSource);
        // or you can use		
        //recorder.PlayRecorded(audioSource);	
    }
}

- OnRecordingSaved fires when recording saved on disk.

Recorder.onSaved += OnRecordingSaved;
void OnRecordingSaved(string path){	Debug.Log("File Saved at : "+path);	recorder.PlayAudio (path, audioSource); // play recorded audio from path}
- OnError fires when any errors occurs.
 Recorder.onError += OnError;
void OnError(string errMsg){	Debug.Log("Error : "+errMsg);}

Use following function to record your audio
1). Init() : Initialize audio recorder, must be called before use of any other functions
2). StartRecording(isLoop, timeInSec) : Start recording your audio from microphone with default frequency supported by microphone.
3). StartRecording(isLoop, timeInSec,frequency) : Start recording your audio from microphone with custom frequency 
4). StopRecording() : Stop Recording
5). PlayRecorded(audioSource) : Play recorded audio, you have pass audio source parameter.
6). PlayAudio(path, audioSource) : Play audio from path.
7). PlayAudio(audioClip, audioSource) : Play audio clip.
8). Save (path,audioClip): Save recorded file to disk.
9). Dispose()  :  Destroy recorded clip or reset everything
10). hasRecorded : Property return ‘true’ if there is something recorded, otherwise returns ‘false’.
11). Clip : Property returns recorded clip of type AudioClip.
12). IsRecording : Property returns ‘true’ if currently recoding is in progress, otherwise returns ‘false’.
13). IsReady : Property returns ‘true’ if successfully Initialized, otherwise returns ‘false’.

