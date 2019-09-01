using AudioSpeaker;

public class AudioSpeakerApi : NatureRemoApi {

    // Singltonパターン
    private static AudioSpeakerApi m_Instance;

    public static AudioSpeakerApi instance {
        get {
            if( m_Instance == null ) m_Instance = new AudioSpeakerApi();
            return m_Instance;
        }
    }
}
