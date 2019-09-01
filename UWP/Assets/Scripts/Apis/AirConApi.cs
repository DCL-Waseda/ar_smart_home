using AirCon;

public class AirConApi : NatureRemoApi {

    // Singltonパターン
    private static AirConApi m_Instance;

    public static AirConApi instance {
        get {
            if( m_Instance == null ) m_Instance = new AirConApi();
            return m_Instance;
        }
    }
}
