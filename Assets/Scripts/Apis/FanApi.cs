using Fan;

public class FanApi : NatureRemoApi {

    // Singltonパターン
    private static FanApi m_Instance;

    public static FanApi instance {
        get {
            if( m_Instance == null ) m_Instance = new FanApi();
            return m_Instance;
        }
    }
}
