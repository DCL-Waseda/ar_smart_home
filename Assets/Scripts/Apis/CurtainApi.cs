using Curtain;

public class CurtainApi : NatureRemoApi {

    // Singltonパターン
    private static CurtainApi m_Instance;

    public static CurtainApi instance {
        get {
            if( m_Instance == null ) m_Instance = new CurtainApi();
            return m_Instance;
        }
    }
}
