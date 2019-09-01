using Display;

public class DisplayApi : NatureRemoApi {

    // Singltonパターン
    private static DisplayApi m_Instance;

    public static DisplayApi instance {
        get {
            if( m_Instance == null ) m_Instance = new DisplayApi();
            return m_Instance;
        }
    }

    public void power(){
        signal_post(Const.POWER_ID);
    }

    public void volume_up(){
        signal_post(Const.VOLUMEUP_ID);
    }

    public void volume_down(){
        signal_post(Const.VOLUMEDOWN_ID);
    }
}
